using Data.Models.SkillEngine;
using Data.Models.World;

namespace Data.Models.Player
{
    public class UseSkillArgs
    {
        public int SkillId;
        public bool IsItemSkill;
        public bool IsTargetAttack;
        public bool IsDelaySkill;
        public bool IsChargeSkill;
        public Position TargetPosition = new Position();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        /// <returns></returns>
        public Skill GetSkill(Creature.Creature creature)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Release()
        {
            //TargetPosition = null;
        }
    }
}
