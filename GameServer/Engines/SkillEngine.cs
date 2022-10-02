using Communicate.Interfaces;
using Data.Models.Creature;
using Data.Models.Player;

namespace GameServer.Engines
{
    public class SkillEngine : ISkillEngine
    {
        public void Action()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="target"></param>
        /// <param name="args"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void UseSkill(Player player, Creature target, UseSkillArgs args)
        {
            throw new System.NotImplementedException();
        }
    }
}
