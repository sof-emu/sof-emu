using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using System;

namespace Communicate.Logics
{
    public class CreatureLogic : Global
    {
        public static void HpChanged(Creature creature, int diff, Creature attacker = null)
        {
            if (creature is Player)
            {
                FeedbackService.HpMpSpChanged(creature as Player);
                //PartyService.SendLifestatsToPartyMembers(((Player)creature).Party);
            }

            ObserverService.NotifyHpChanged(creature);
        }

        public static void MpChanged(Creature creature, int diff, Creature attacker = null)
        {
            ObserverService.NotifyMpChanged(creature);

            if (creature is Player)
            {
                FeedbackService.HpMpSpChanged(creature as Player);
                //PartyService.SendLifestatsToPartyMembers(((Player)creature).Party);
            }
        }

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

        public static void NpcDied(Npc npc)
        {
            var player = npc.Ai.GetKiller() as Player;

            if (player != null)
            {
                // QuestEngine.OnPlayerKillNpc(player, npc);

                player.Instance.OnNpcKill(player, npc);
            }

            FeedbackService.NpcDied(player, npc);
            npc.Ai.DealExp();

            if (player != null)
            {
                MapService.CreateDrop(npc, player);
            }
        }
    }
}
