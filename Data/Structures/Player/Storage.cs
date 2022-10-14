using Data.Enums.Item;
using System.Collections.Generic;

namespace Data.Structures.Player
{
    public class Storage
    {
        public Dictionary<int, StorageItem> Items = new Dictionary<int, StorageItem>();
        public Dictionary<int, StorageItem> EquipItems = new Dictionary<int, StorageItem>(30);

        public object ItemsLock = new object();

        public long Money = 100;
        public short Size = 36;
        public short Weight = 500;

        public StorageType StorageType;

        public Storage()
        {
            for (int i = 0; i < 15; i++)
            {
                EquipItems.Add(i, null);
            }
        }

        public bool IsFull()
        {
            int count = 0;
            if (StorageType == StorageType.Inventory)
                for (int i = 20; i < Size + 20; i++)
                {
                    if (Items.ContainsKey(i))
                        count++;
                }
            else
                count = Items.Count;

            return count >= Size;
        }

        public bool IsEmpty(int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                if (Items.ContainsKey(i))
                    return false;
            }
            return true;
        }

        public StorageItem GetItem(int slot)
        {
            lock (ItemsLock)
            {
                if (Items.ContainsKey(slot))
                    return Items[slot];
            }

            return null;
        }

        public StorageItem GetEquipItem(int slot)
        {
            lock (ItemsLock)
            {
                if (EquipItems.ContainsKey(slot))
                    return EquipItems[slot];
            }

            return null;
        }

        public int GetFreeSlot(int offset = 0)
        {
            lock (ItemsLock)
            {
                for (int i = offset; i < Size; i++)
                    if (StorageType == StorageType.Inventory)
                    {
                        if (!Items.ContainsKey(i))
                            return i;
                    }
                    else
                    {
                        if (!Items.ContainsKey(i))
                            return i;
                    }
            }
            return -1;
        }

        public int LastIdRanged(int from, int to)
        {
            for (int i = to; i >= from; i--)
                if (Items.ContainsKey(i))
                    return i;

            return 0;
        }

        public long? GetItemId(int slot)
        {
            lock (ItemsLock)
            {
                if (Items.ContainsKey(slot))
                    return Items[slot].ItemId;
            }

            return null;
        }

        public void Release()
        {
            foreach (StorageItem item in Items.Values)
                item.Release();

            Items = null;
            ItemsLock = null;
        }

        /*public void ReleaseUniqueIds()
        {
            foreach (StorageItem item in Items.Values)
                item.ReleaseUniqueId();
        }*/

        public Dictionary<int, StorageItem> GetItemsById(long itemId)
        {
            var itms = new Dictionary<int, StorageItem>();
            lock (ItemsLock)
                foreach (KeyValuePair<int, StorageItem> itm in Items)
                {
                    if (itm.Value.ItemId == itemId)
                        itms.Add(itm.Key, itm.Value);
                }
            return itms;
        }

        public StorageItem GetItemById(long itemId)
        {
            lock (ItemsLock)
                foreach (KeyValuePair<int, StorageItem> itm in Items)
                {
                    if (itm.Value.ItemId == itemId)
                        return itm.Value;
                }
            return null;
        }
    }
}
