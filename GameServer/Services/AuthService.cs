using Data.Interfaces;
using Data.Models.Account;
using GameServer.Networks;
using Newtonsoft.Json;
using Utility;

namespace GameServer.Services
{
    public class AuthService : IService
    {
        public async void Authenticate(Session session, string username, string ip, string mac)
        {
            AccountData accountData = await GameServer
                .ApiService
                .RequestAccountData(username);

            if (accountData == null)
                return;

            // todo send Auth Response
            session.SetAccount(accountData);
            // todo load exists player
            var playerList = await GameServer
                .ApiService
                .GetPlayerFromAccountId(accountData.Id);

            playerList.ForEach(player =>
            {
                session.AddPlayer(player);
            });

            GameServer
                .FeedbackService
                .OnAuthorized(session);
        }
    }
}
