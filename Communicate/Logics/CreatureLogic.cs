using Data.Structures.Creature;
using Data.Structures.Player;

namespace Communicate.Logics
{
    public class CreatureLogic : Global
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        /// <returns></returns>
        public static CreatureBaseStats InitGameStats(Creature creature)
        {
            return StatsService.InitStats(creature);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        public static void UpdateCreatureStats(Creature creature)
        {
            StatsService.UpdateStats(creature);

            Player player = creature as Player;
            if (player != null)
            {
                FeedbackService.StatsUpdated(player);
            }
        }
    }
}
