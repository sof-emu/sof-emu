using Data.Interfaces;
using Data.Structures.Player;
using Data.Structures.World;

namespace Communicate.Interfaces
{
    public interface INpcService : IComponent
    {
        void NpcInteraction(ISession session, int shopId, int actionId, int tabIndex);
    }
}
