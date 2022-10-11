using Communicate;
using Communicate.Interfaces;
using Data.Enums;
using Data.Interfaces;
using Data.Structures.Npc;
using Data.Structures.Player;
using GameServer.Networks.Packets.Response;
using System.Numerics;
using System.Threading.Tasks;
using Utility;

namespace GameServer.Services
{
    public class FeedbackService : IFeedbackService
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
            new ResponseAuth(session.Account)
                .Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="player"></param>
        public void OnCreatePlayerResult(ISession session, Player player)
        {
            if(player != null)
            {
                session
                    .Account
                    .Players
                    .Add(player);

                new ResponseCreatePlayer(true)
                    .Send(session);

                Task.Delay(1000);

                Global
                    .PlayerService
                    .SendPlayerLists(session);
            }
            else
                new ResponseCreatePlayer(false)
                    .Send(session);
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

            Global
                .VisibleService
                .Broadcast(player, new ResponsePlayerMove(player, x1, y1, z1, x2, y2, z2, distance, target));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SendServerTime(ISession session)
        {
            if(session.Player != null)
                new ResponseServerTime((int)Global.ServerTime)
                    .Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="npc"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SelectNpc(ISession session, Npc npc)
        {
            new ResponseSelectNpc(npc)
                .Send(session);
        }

        public void SendDeletePlayer(ISession session, int index, bool result)
        {
            new ResponseDeletePlayer(index, result)
                .Send(session);
        }

        public void SendInitailData(ISession session)
        {
            new ResponseServerTime((int)Global.ServerTime).Send(session);
            new ResponsePlayerRunning(1).Send(session);

            new ResponseSkillPassive().Send(session);
            new ResponsePlayerInfo(session.Player).Send(session);

            new ResponseInventoryInfo(InventoryType.Item).Send(session);
            new ResponseInventoryInfo(InventoryType.Orb).Send(session);
            new ResponseQuestItem().Send(session);

            new ResponsePlayerQuickInfo(session.Player).Send(session);

            new ResponseWeightMoney(session.Player).Send(session);
            new ResponsePetInfo().Send(session);

            new ResponsePlayerHpMpSp(session.Player).Send(session);

            new ResponseQuestList().Send(session);
            new ResponseQuestCompleteList().Send(session);

            new ResponseViewProfile().Send(session);
        }

        public void StatsUpdated(Player player)
        {
            new ResponsePlayerStats(player).Send(player.Session);
        }

        public void OnPlayerEnterWorld(ISession session, Player player)
        {
            player.Session.Account.lastOnlineUtc = Funcs.GetCurrentMilliseconds();
        }
    }
}
