using Data.Interfaces;
using Data.Models.Creature;
using Data.Models.Player;
using Data.Models.World;
using System;
using System.Collections.Generic;
using Utility;

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

            MapService.Init();

            InitMainLoop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public static void ClientPing(ISession session)
        {
            if ((int)DateTime.Now.Subtract(session.GetLastPing()).TotalMilliseconds < 10000)
            {
                int times = 0;
                hackSpeedDetect.TryGetValue(session.SessionId, out times);
                times++;
                if(times > 3)
                {
                    // todo send system hint
                    // The game runs abnormally
                    // disconnect client
                }
            }
            session.SetLastPing(DateTime.Now);

            // todo
            FeedbackService
                .SendServerTime(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public static void ViewProfile(Player player)
        {
            FeedbackService
                .SendViewProfile(player);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public static void SendMapNpcList(Player player)
        {
            MapInstance map = player.GetMap();
            NpcService.SendNpcList(player, map);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="targetId"></param>
        /// <param name="skillId"></param>
        /// <param name="pos"></param>
        /// <param name="unk1"></param>
        public static void AttackTarget(Player player, int targetId, int skillId, Position pos, int unk1)
        {
            Creature target = player
                .GetMap()
                .GetNpc(targetId);

            UseSkillArgs args = new UseSkillArgs()
            {
                SkillId = skillId,
                TargetPosition = pos
            };

            if (skillId == 0)
                AttackEngine.Attack(player, target, args);
            else
                SkillEngine.UseSkill(player, target, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        public static void AttackStageEnd(Creature creature)
        {
            Player player = creature as Player;
            Log.Debug($"player.Attack.Args {player.Attack.Args.TargetPosition.X}");
            if (player != null)
                if (player.Attack.Args.SkillId == 0)
                    AttackEngine.Attack(player, player.GetTarget(), player.Attack.Args);
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
