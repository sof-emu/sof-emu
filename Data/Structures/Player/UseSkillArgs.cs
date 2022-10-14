using Data.Structures.SkillEngine;
using Data.Structures.World;

namespace Data.Structures.Player
{
    public class UseSkillArgs
    {
        public int SkillId;

        public bool IsItemSkill = false;

        public bool IsTargetAttack = false;

        public bool IsDelaySkill = false;

        public bool IsChargeSkill = true;

        public bool IsDelayStart;

        public WorldPosition TargetPosition = new WorldPosition();

        public Skill GetSkill(Creature.Creature creature)
        {
            if (Data.Skills.ContainsKey(SkillId))
                return Data.Skills[SkillId];

            return null;
        }

        public void Release()
        {
            TargetPosition = null;
        }
    }
}
