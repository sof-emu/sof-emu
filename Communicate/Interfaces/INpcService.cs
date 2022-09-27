using Data.Interfaces;
using Data.Models.Player;
using Data.Models.World;

namespace Communicate.Interfaces
{
    public interface INpcService : IComponent
    {
        void NpcInteraction(ISession session, int shopId, int actionId, int tabIndex);
        void SendNpcList(Player player, MapInstance map);
    }
}
