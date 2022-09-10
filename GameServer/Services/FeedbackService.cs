using Data.Interfaces;
using GameServer.Networks;
using GameServer.Networks.Packets.Response;

namespace GameServer.Services
{
    public class FeedbackService : IService
    {
        public void OnAuthorized(Session session)
        {
            new ResponseAuth(session.GetAccount())
                .Send(session);

            SendPlayerLists(session);
        }

        public void SendPlayerLists(Session session)
        {
            /*if (session.GetPlayers().Count > 0)
            {
                int seq = 0;
                session.GetPlayers().ForEach(player =>
                {
                    seq++;
                    // (player.GetSession() as Session).hash;
                    // new SpPlayerList(seq, connection.Account.Players[i], CharacterListResponse.Exists).Send(connection);
                });
            }
            else*/
                new ResponsePlayerList().Send(session);
        }
    }
}
