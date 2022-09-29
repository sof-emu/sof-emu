using Data.Interfaces;
using Data.Models.Creature;
using Data.Models.Player;

namespace Communicate.Interfaces
{
    public interface IVisibleService : IComponent
    {
        void Broadcast(Creature creature, ISendPacket packet);
    }
}
