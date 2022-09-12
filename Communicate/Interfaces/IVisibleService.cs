using Data.Interfaces;
using Data.Models.Creature;

namespace Communicate.Interfaces
{
    public interface IVisibleService : IComponent
    {
        void Send(Creature creature, ISendPacket packet);
    }
}
