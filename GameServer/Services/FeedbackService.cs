using Communicate;
using Communicate.Interfaces;
using Data.Interfaces;
using Data.Models.Player;
using GameServer.Networks;
using GameServer.Networks.Packets.Response;
using System.Threading.Tasks;
using Utility;

namespace GameServer.Services
{
    public class FeedbackService : IFeedbackService
    {
        public void OnAuthorized(ISession session)
        {
            new ResponseAuth(session.GetAccount())
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
                    .AddPlayer(player);

                new ResponseCreatePlayer(true)
                    .Send(session);

                Task.Delay(1000);

                GameServer
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
            Global
                .VisibleService
                .Send(player, new ResponsePlayerMove(player, x1, y1, z1, x2, y2, z2, distance, target));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void SendViewProfile(Player player)
        {
            new ResponseViewProfile().Send(player.GetSession());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SendServerTime(ISession session)
        {
            Log.Debug($"SendServerTime: {(int)Global.ServerTime}");
            new ResponseServerTime((int)Global.ServerTime).Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Action()
        {
            
        }

        
    }
}
