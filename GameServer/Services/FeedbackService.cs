using Data.Interfaces;
using GameServer.Networks;
using GameServer.Networks.Packets.Response;
using System;
using System.Threading.Tasks;
using Utility;

namespace GameServer.Services
{
    public class FeedbackService : IService
    {
        public async void OnAuthorized(Session session)
        {
            new ResponseAuth(session.GetAccount())
                .Send(session);
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

        public async void CheckNameExist(Session session, string name)
        {
            bool isExists = await GameServer
                .ApiService
                .CheckNameExist(name);

            Log.Debug($"isExists: {isExists}");

            new ResponseCheckName(name, isExists).Send(session);
        }
    }
}
