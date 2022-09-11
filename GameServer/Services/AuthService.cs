using Communicate;
using Communicate.Interfaces;
using Data.Interfaces;
using Data.Models.Account;
using GameServer.Networks;
using Newtonsoft.Json;
using Utility;

namespace GameServer.Services
{
    public class AuthService : IAuthService
    {
        

        public async void Authenticate(ISession session, string username, string ip, string mac)
        {
            AccountData accountData = await Global
                .ApiService
                .RequestAccountData(username);

            if (accountData == null)
                return;

            // todo send Auth Response
            session.SetAccount(accountData);
            // todo load exists player
            var playerList = await Global
                .ApiService
                .GetPlayerFromAccountId(accountData.Id);

            playerList.ForEach(player =>
            {
                session.AddPlayer(player);
            });

            Global
                .FeedbackService
                .OnAuthorized(session);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Action()
        {

        }
    }
}
