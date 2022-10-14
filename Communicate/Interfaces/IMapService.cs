using Data.Structures.Npc;
using Data.Structures.Player;

namespace Communicate.Interfaces
{
    public interface IMapService : IComponent
    {
        void CreateDrop(Npc npc, Player player);
        void Init();
        bool IsDungeon(int mapId);
        void PlayerEnterWorld(Player player);
        void PlayerLeaveWorld(Player player);
    }
}
