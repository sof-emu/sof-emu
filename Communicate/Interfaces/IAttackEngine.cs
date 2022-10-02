using Data.Models.Creature;
using Data.Models.Player;
using Data.Models.World;

namespace Communicate.Interfaces
{
    public interface IAttackEngine : IComponent
    {
        void Attack(Player player, Creature target, UseSkillArgs args);
    }
}
