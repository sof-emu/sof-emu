using Data.Enums.Item;
using System.Collections.Generic;

namespace Data.Structures.Player
{
    public class Storage
    {
        public Dictionary<int, StorageItem> Items = new Dictionary<int, StorageItem>();

        public object ItemsLock = new object();

        public long Money = 100;

        public short Weight = 500;

        public StorageType StorageType;
    }
}
