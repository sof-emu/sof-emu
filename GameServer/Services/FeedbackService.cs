using Data.Interfaces;
using Data.Models.Player;
using GameServer.Networks;
using GameServer.Networks.Packets.Response;
using System.Threading.Tasks;

namespace GameServer.Services
{
    public class FeedbackService : IService
    {
        public void OnAuthorized(Session session)
        {
            new ResponseAuth(session.GetAccount())
                .Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="player"></param>
        public void OnCreatePlayerResult(Session session, Player player)
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
    }
}
