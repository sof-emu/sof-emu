using Communicate;
using Communicate.Interfaces;
using Data.Enums;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.SkillEngine;
using Data.Structures.World;
using GameServer.Networks.Packets;
using GameServer.Networks.Packets.Response;
using System;
using System.Collections.Generic;
using Utility;

namespace GameServer.Services
{
    public class FeedbackService : Global, IFeedbackService
    {
        /// <summary>
        /// 
        /// </summary>
        public void Action()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public void OnAuthorized(ISession session)
        {
            new ResponseAuth(session.Account).Send(session);
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
        /// <param name="tagert"></param>
        public void PlayerMoved(Player player, float x1, float y1, float z1, float x2, float y2, float z2, float distance, int target)
        {
            //player
            //    .Moved(x1, y1, z1, x2, y2, z2);

            VisibleService
                .Send(player, new ResponsePlayerMove(player, x1, y1, z1, x2, y2, z2, distance, target));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SendServerTime(ISession session)
        {
            if(session.Player != null)
                new ResponseServerTime((int)Global.ServerTime).Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="npc"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SelectNpc(ISession session, Npc npc)
        {
            if(npc != null)
                new ResponseSelectNpc(npc).Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="index"></param>
        /// <param name="result"></param>
        public void SendDeletePlayer(ISession session, int index, bool result)
        {
            new ResponseDeletePlayer(index, result).Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public void SendInitailData(ISession session)
        {
            new ResponseServerTime((int)Global.ServerTime).Send(session);
            new ResponsePlayerRunning(1).Send(session);

            new ResponseSkillPassive().Send(session);
            new ResponsePlayerInfo(session.Player).Send(session);

            new ResponseInventoryInfo(InventoryType.Item).Send(session);
            new ResponseInventoryInfo(InventoryType.Orb).Send(session);
            new ResponseQuestItem().Send(session);

            //new ResponsePlayerQuickInfo(session.Player).Send(session);

            new ResponseWeightMoney(session.Player).Send(session);
            //new ResponsePetInfo().Send(session);

            new ResponsePlayerHpMpSp(session.Player).Send(session);

            new ResponseQuestList().Send(session);
            new ResponseQuestCompleteList().Send(session);

            //new ResponseViewProfile().Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void StatsUpdated(Player player)
        {
            new ResponsePlayerStats(player).Send(player.Session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="player"></param>
        public void OnPlayerEnterWorld(ISession session, Player player)
        {
            player.Session.Account.lastOnlineUtc = Funcs.GetCurrentMilliseconds();

            SystemMessages.EnterGameMessage.Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="result"></param>
        public void SendCreatePlayerResult(ISession session, bool result)
        {
            new ResponseCreatePlayer(result).Send(session);
            //SendPlayerList(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public void SendPlayerList(ISession session)
        {
            if(session.Account.Players.Count > 0)
                session.Account.Players.ForEach(player => new ResponsePlayerList(player).Send(session));
            else
                new ResponsePlayerList().Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        /// <param name="result"></param>
        public void SendCheckNameResult(ISession session, string name, CheckNameResult result)
        {
            new ResponseCheckName(name, result).Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="creature"></param>
        public void SendRemoveCreature(ISession session, Creature creature)
        {
            var player = creature as Player;
            if (player != null)
            {
                //new SpPlayerRemove(player).Send(connection);
                return;
            }

            var npc = creature as Npc;
            if (npc != null)
            {
                //new SpNpcDespawn(npc).Send(connection);
            }

            var item = creature as Item;
            if (item != null)
            {
                //new SpDropRemove(item).Send(connection);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="creature"></param>
        public void SendCreatureInfo(ISession session, Creature creature)
        {
            var player = creature as Player;
            if (player != null)
            {
                try
                {
                    new ResponsePlayerInfo(player).Send(session);
                }
                catch (Exception e)
                {
                    Log.Error("Exception " + e);
                }

                return;
            }

            var npc = creature as Npc;
            if (npc != null)
            {
                try
                {
                    List<Npc> npcs = new List<Npc>() { npc };
                    new ResponseNpcSpawn(npcs).Send(session);
                }
                catch (Exception e)
                {
                    Log.Error("Exception " + e);
                }

                return;
            }

            //var item = creature as Item;
            //if (item != null)
            //{
            //    new SpDropInfo(item).Send(connection);
            //    return;
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void PlayerDied(Player player)
        {
            //WorldPosition bindPoint = GetNearestBindPoint(player);
            //player.ClosestBindPoint = bindPoint;

            //Global.VisibleService.Send(player, new SpCreatureDied(player));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void HpMpSpChanged(Player player)
        {
            // Global.VisibleService.Send(player, new SpPlayerHpMpSp(player));
        }

        public void PlayerLevelUp(Player player)
        {
            //Global.VisibleService.Send(player, new SpPlayerLevelUp(player));
            //Global.VisibleService.Send(player, new SpPlayerHpMpSp(player));
        }

        public void AttackStageEnd(Creature creature)
        {
            VisibleService.Send(creature, new ResponseAttack(creature as Player, creature.Attack));
        }

        public void NpcDied(Player player, Npc npc)
        {
            VisibleService.Send(player, new ResponseCreatureDied(npc));
        }
    }
}
