using Data.Interfaces;
using Data.Models.Creature;

namespace Communicate.Interfaces
{
    public interface IVisibleService : IComponent
    {
        void Broadcast(Creature creature, ISendPacket packet);
    }
}
