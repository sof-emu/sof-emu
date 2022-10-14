using Data.Interfaces;
using Data.Structures.Creature;

namespace Communicate.Interfaces
{
    public interface IVisibleService : IComponent
    {
        void Send(Creature creature, ISendPacket packet);
    }
}
