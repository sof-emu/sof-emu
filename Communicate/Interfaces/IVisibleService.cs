using Data.Interfaces;
using Data.Structures.Creature;

namespace Communicate.Interfaces
{
    public interface IVisibleService : IComponent
    {
        void Broadcast(Creature creature, ISendPacket packet);
    }
}
