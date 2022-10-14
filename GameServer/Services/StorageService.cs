using Communicate.Interfaces;
using Data.Enums.Item;
using Data.Structures.Player;
using GameServer.Networks.Packets;
using GameServer.Networks.Packets.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace GameServer.Services
{
    public class StorageService : IStorageService
    {
        public void Action()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="storage"></param>
        /// <param name="itemId"></param>
        /// <param name="count"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public bool AddItem(Player player, Storage storage, int itemId, int count, int slot = -1)
        {
            if (count < 0)
                return false;

            if (slot > (storage.StorageType == StorageType.Inventory ? storage.Size + 20 : storage.Size))
                return false;

            if ((storage.StorageType == StorageType.Inventory && slot < 20 && slot != -1))
                return false;

            if (slot < -1)
                return false;

            lock (storage.ItemsLock)
            {
                int stackSize = 99;

                if (storage.IsFull())
                {
                    SystemMessages.InventoryIsFull.Send(player.Session);
                    return false;
                }

                if (slot != -1)
                {
                    // Certain slot + Stackable
                    if (storage.Items.ContainsKey(slot))
                    {
                        //new SpChatMessage(player, string.Format("You Cant Put Item {0} In Inventory!!", ItemTemplate.Factory(itemId).Name), ChatType.Info).Send(player.Connection);
                        return false;
                    }

                    storage.Items.Add(slot, new StorageItem { ItemId = itemId, Amount = count, State = ItemState.NEW });
                }
                else
                {
                    #region Any slot + Stackable
                    Dictionary<int, StorageItem> itemsById = storage.GetItemsById(itemId);

                    int canBeAdded =
                        itemsById.Values.Where(storageItem => storageItem.Amount < stackSize).Sum(
                            storageItem => stackSize - storageItem.Amount);

                    if (canBeAdded >= count)
                    {
                        foreach (var storageItem in itemsById.Values)
                        {
                            int added = Math.Min(stackSize - storageItem.Amount, count);
                            storageItem.Amount += added;
                            storageItem.State = ItemState.UPDATE;
                            count -= added;
                            if (count == 0)
                                break;
                        }
                    }
                    else
                    {
                        if (storage.IsFull() || count > GetFreeSlots(storage).Count * stackSize)
                        {
                            // new SpChatMessage(player, "Inventory Full!!", ChatType.House, true).Send(player.Connection);
                            return false;
                        }

                        foreach (var storageItem in itemsById.Values)
                        {
                            int added = Math.Min(stackSize - storageItem.Amount, count);
                            storageItem.Amount += added;
                            storageItem.State = ItemState.UPDATE;
                            count -= added;
                        }
                        while (count > 0)
                        {
                            int added = Math.Min(stackSize, count);
                            StorageItem item = new StorageItem { ItemId = itemId, Amount = added, State = ItemState.NEW };
                            storage.Items.Add(storage.GetFreeSlot(), item);
                            count -= added;
                        }
                    }
                    #endregion
                }
            }

            ShowPlayerStorage(player, storage.StorageType);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="storage"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddItem(Player player, Storage storage, StorageItem item)
        {
            lock (storage.ItemsLock)
            {
                if (item.ItemId == 0)
                {
                    Log.Debug("Item UID[{0}]: ItemId = {1}", item.UID, item.ItemId);
                    return false;
                }

                int maxStack = CanStack(item) ? 99 : 1;
                int canStacked = 1;

                if (maxStack > 1)
                {
                    for (int i = 0; i < storage.Size; i++)
                    {
                        if (!storage.Items.ContainsKey(i))
                            continue;

                        if (storage.Items[i].ItemId == item.ItemId)
                        {
                            canStacked += maxStack - storage.Items[i].Amount;

                            if (canStacked >= item.Amount)
                                break;
                        }
                    }
                }

                if (canStacked < item.Amount && GetFreeSlots(storage).Count < 1)
                    return false;

                if (canStacked > 0)
                {
                    for (int i = 0; i < storage.Size; i++)
                    {
                        if (!storage.Items.ContainsKey(i)) continue;

                        if (storage.Items[i].ItemId == item.ItemId)
                        {
                            int put = maxStack - storage.Items[i].Amount;
                            if (item.Amount < put)
                                put = item.Amount;

                            storage.Items[i].Amount += put;
                            storage.Items[i].State = ItemState.UPDATE;
                            item.Amount -= put;

                            if (item.Amount <= 0)
                                break;
                        }
                    }
                }

                if (item.Amount > 0)
                {
                    storage.Items.Add(storage.GetFreeSlot(), item);
                }
                ShowPlayerStorage(player, storage.StorageType);
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void AddStartItemsToPlayer(Player player)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        public List<int> GetFreeSlots(Storage storage)
        {
            var freeSlots = new List<int>();

            for (int i = 0; i <= storage.Size; i++)
                if (!storage.Items.ContainsKey(i))
                    freeSlots.Add(i);

            return freeSlots;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="storageType"></param>
        /// <param name="shadowUpdate"></param>
        /// <param name="offset"></param>
        public void ShowPlayerStorage(Player player, StorageType storageType, bool shadowUpdate = true, int offset = 0)
        {
            switch (storageType)
            {
                case StorageType.Inventory:
                    new ResponseWeightMoney(player).Send(player.Session);
                    new ResponseInventoryInfo(player.Inventory).Send(player.Session);
                    //DataBaseStorage.SavePlayerStorage(player.PlayerId, player.Inventory);
                    break;
                case StorageType.CharacterWarehouse:

                    break;
                case StorageType.Trade:
                    // Updates are sent by the controller
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool CanStack(StorageItem item)
        {
            bool retval = true;

            return retval;
        }
    }
}
