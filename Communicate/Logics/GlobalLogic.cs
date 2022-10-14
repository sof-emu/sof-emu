using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Player;
using System.Collections.Generic;

namespace Communicate.Logics
{
    public class GlobalLogic : Global
    {
        protected static Dictionary<int, int> hackSpeedDetect = new Dictionary<int, int>();

        /// <summary>
        /// 
        /// </summary>
        public static void ServerStart()
        {
            Data.Data.LoadAll();

            StatsService.Init();
            MapService.Init();

            InitMainLoop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public static void ClientPing(ISession session)
        {
            session.Ping();

            // todo
            FeedbackService
                .SendServerTime(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        public static void AttackStageEnd(Creature creature)
        {
            Player player = creature as Player;

            if (player != null)
                if (player.Attack.Args.SkillId == 0)
                    SkillEngine.UseSkill(player.Session, player.Attack.Args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        public static void AttackFinished(Creature creature)
        {

        }
    }
}
