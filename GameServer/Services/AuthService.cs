using Communicate;
using Communicate.Interfaces;
using Data.Interfaces;
using Data.Models.Account;
using Data.Models.Creature;
using Data.Models.Player;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

            List<Player> _Players = new List<Player>();

            playerList.ForEach(async player =>
            {
                GameStats stats = await Global
                    .ApiService
                    .GetPlayerStats(player.Id);

                player.SetGameStats(stats);
                player.SetSession(session);
                _Players.Add(player);
            });

            await Task.Delay(1000);

            session.SetPlayer(_Players);

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
