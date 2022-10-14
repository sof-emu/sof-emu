using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.SkillEngine;
using System.Collections.Generic;

namespace Communicate.Interfaces
{
    public interface ISkillEngine : IComponent
    {
        void Init();
        void UseSkill(ISession session, UseSkillArgs args);
        void UseSkill(ISession session, List<UseSkillArgs> argsList);
        void UseSkill(Npc npc, Skill skill);
        void MarkTarget(ISession session, Creature target);
        void ReleaseAttack(Player player, int attackUid, int type);
        void AttackFinished(Creature creature);
    }
}
