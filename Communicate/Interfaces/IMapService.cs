using Data.Models.Player;

namespace Communicate.Interfaces
{
    public interface IMapService : IComponent
    {
        void EnterWorld(Player player);
        void Init();
    }
}
