using Data.Models.Player;
using Data.Models.World;

namespace Communicate.Interfaces
{
    public interface INpcService : IComponent
    {
        void SendNpcList(Player player, MapInstance map);
    }
}
