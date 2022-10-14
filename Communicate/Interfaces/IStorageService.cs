using Data.Enums.Item;
using Data.Structures.Player;
using System.Collections.Generic;

namespace Communicate.Interfaces
{
    public interface IStorageService : IComponent
    {
        void AddStartItemsToPlayer(Player player);
        void ShowPlayerStorage(Player player, StorageType storageType, bool shadowUpdate = true, int offset = 0);
        bool AddItem(Player player, Storage storage, int itemId, int itemCounter, int slot = -1);
        bool AddItem(Player player, Storage inventory, StorageItem item);
        List<int> GetFreeSlots(Storage storage);
    }
}
