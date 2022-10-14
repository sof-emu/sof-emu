using Data.Enums;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Player;
using Data.Structures.World;
using System;
using System.Linq;

namespace Communicate.Logics
{
    public class PlayerLogic : Global
    {
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="playerIndex"></param>
        public static void PlayerSelected(ISession session, int playerIndex)
        {
            session.Player = session.Account.Players.FirstOrDefault(player => player.Index == playerIndex);

            if (session.Player == null)
                return;

            session.Player.Session = session;

            PlayerService.InitPlayer(session.Player);
            FeedbackService.SendInitailData(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public static void PlayerEnterWorld(Player player)
        {
            MapService.PlayerEnterWorld(player);
            //PlayerService.PlayerEnterWorld(player);
            //ControllerService.PlayerEnterWorld(player);
            FeedbackService.OnPlayerEnterWorld(player.Session, player);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public static void PlayerEndGame(Player player)
        {
            if (player == null) return;

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        public static void CheckName(ISession session, string name)
        {
            CheckNameResult result = PlayerService.CheckName(name);
            FeedbackService.SendCheckNameResult(session, name, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="distance"></param>
        /// <param name="target"></param>
        public static void PlayerMoved(Player player, float x1, float y1, float z1, float x2, float y2, float z2, float distance, int target)
        {
            //Log.Debug($"PlayerMoved: {x1}, {y1}, {z1},{x2}, {y2}, {z2}, {distance}, {target}");
            PlayerService.PlayerMoved(player, x1, y1, z1, x2, y2, z2, distance, target);
            FeedbackService.PlayerMoved(player, x1, y1, z1, x2, y2, z2, distance, target);

            //PartyService.SendMemberPositionToPartyMembers(player);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="statisticId"></param>
        public static void SelectNpc(ISession session, int statisticId)
        {
            /*Npc npc = session
                .GetSelectedPlayer()
                .GetMap()
                .GetNpc(statisticId);

            FeedbackService
                .SelectNpc(session, npc);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        /// <param name="playerClass"></param>
        /// <param name="hairColor"></param>
        /// <param name="voice"></param>
        /// <param name="gender"></param>
        public static void CreatePlayer(ISession session, string name, PlayerClass playerClass, string hairColor, int voice, int gender)
        {
            if(session.Account.Players.Count >= 5)
                FeedbackService.SendCreatePlayerResult(session, false);

            Player player = PlayerService.CreatePlayer(session, name, playerClass, hairColor, voice, gender);

            FeedbackService.SendCreatePlayerResult(session, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="index"></param>
        /// <param name="password"></param>
        public static void DeletePlayer(ISession session, int index, string password)
        {
            //Player p = session.GetPlayer(index);

            //var result = await ApiService
            //    .SendDeletePlayer(p.PlayerId, password);

            bool result = false;

            // todo send packet delete response
            FeedbackService
                .SendDeletePlayer(session, index, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="creature"></param>
        public static void OutOfVision(Player player, Creature creature)
        {
            ObserverService.RemoveObserved(player, creature);
            FeedbackService.SendRemoveCreature(player.Session, creature);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="creature"></param>
        public static void InTheVision(Player player, Creature creature)
        {
            FeedbackService.SendCreatureInfo(player.Session, creature);

            /*Npc npc = creature as Npc;
            if (npc != null)
                QuestEngine.ShowIcon(player, npc);*/
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public static void PleyerDied(Player player)
        {
            CreatureLogic.UpdateCreatureStats(player);
            FeedbackService.PlayerDied(player);
        }

        public static void LevelUp(Player player)
        {
            player.LifeStats.LevelUp();

            FeedbackService.PlayerLevelUp(player);
            StatsService.UpdateStats(player);
            //QuestEngine.PlayerLevelUp(player);
        }
    }
}
