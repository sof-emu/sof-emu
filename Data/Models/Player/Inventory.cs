using System.Collections.Generic;
using System.Linq;

namespace Data.Models.Player
{
    public class Inventory
    {
        private Dictionary<int, InventoryItem> inventoryItems;
        private Dictionary<int, InventoryItem> equipItems;

        private Player player;
        private object ItemsLock = new object();
        private long money = 100;
        private short size = 36;
        private int maxWeight = 500;

        public Inventory(Player player)
        {
            inventoryItems = new Dictionary<int, InventoryItem>();
            equipItems = new Dictionary<int, InventoryItem>();

            Enumerable
                .Range(0, 15)
                .ToList()
                .ForEach(i => equipItems.Add(i, null));

            this.player = player;
        }


        public long Money
        {
            get { return money; }
            set { money = value; }
        }
        public short Size
        {
            get { return size; }
            set { size = value; }
        }
        public int TotalWeight
        {
            get
            {
                // todo return sum of item weight
                return 0;
            }
        }
        public int MaxWeight
        {
            get { return maxWeight + (player.Level * 20); }
            set { maxWeight = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            int count = 0;
            for (int i = 20; i < size + 20; i++)
                if (inventoryItems.ContainsKey(i))
                    count++;

            return count >= size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool IsEmpty(int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                if (inventoryItems.ContainsKey(i))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        public InventoryItem GetItem(int slot)
        {
            lock (ItemsLock)
            {
                if (inventoryItems.ContainsKey(slot))
                    return inventoryItems[slot];
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        public InventoryItem GetEquipItem(int slot)
        {
            lock (ItemsLock)
            {
                if (equipItems.ContainsKey(slot))
                    return equipItems[slot];
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <returns></returns>
        public int GetFreeSlot(int offset = 0)
        {
            lock (ItemsLock)
            {
                for (int i = offset; i < size; i++)
                    if (!inventoryItems.ContainsKey(i))
                        return i;
            }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int LastIdRanged(int from, int to)
        {
            for (int i = to; i >= from; i--)
                if (inventoryItems.ContainsKey(i))
                    return i;

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="slot"></param>
        /// <returns></returns>
        public long? GetItemId(int slot)
        {
            lock (ItemsLock)
            {
                if (inventoryItems.ContainsKey(slot))
                    return inventoryItems[slot].ItemId;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Dictionary<int, InventoryItem> GetItemsById(int itemId)
        {
            var itms = new Dictionary<int, InventoryItem>();
            lock (ItemsLock)
                foreach (KeyValuePair<int, InventoryItem> itm in inventoryItems)
                {
                    if (itm.Value.ItemId == itemId)
                        itms.Add(itm.Key, itm.Value);
                }
            return itms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public InventoryItem GetItemById(int itemId)
        {
            lock (ItemsLock)
                foreach (KeyValuePair<int, InventoryItem> itm in inventoryItems)
                {
                    if (itm.Value.ItemId == itemId)
                        return itm.Value;
                }
            return null;
        }
    }
}
