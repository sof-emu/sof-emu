using Data.Interfaces;
using Data.Structures.Creature;

namespace Communicate.Interfaces
{
    public interface IAiService : IComponent
    {
        IAi CreateAi(Creature creature);
    }
}
