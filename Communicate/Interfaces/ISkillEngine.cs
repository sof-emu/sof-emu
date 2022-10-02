using Data.Models.Creature;
using Data.Models.Player;
using Data.Models.World;

namespace Communicate.Interfaces
{
    public interface ISkillEngine : IComponent
    {
        void UseSkill(Player player, Creature target, UseSkillArgs args);
    }
}
