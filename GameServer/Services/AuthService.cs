using Communicate;
using Communicate.Interfaces;
using Data.Interfaces;
using Data.Structures.Account;
using System.Threading.Tasks;
using Utility;

namespace GameServer.Services
{
    public class AuthService : IAuthService
    {
        public void Authenticate(ISession session, string username, string ip, string mac)
        {
            Log.Debug($"Authenticate: {username}");

            Account accountData = Global
                .AccountRepository
                .GetAccountByUsername(username);

            if (accountData == null)
                return;

            // todo send Auth Response
            session.SetAccount(accountData);
            // todo load exists player
            var playerList = Global
                .PlayerRepository
                .GetPlayerFromAccountId(accountData.Id);

            playerList.ForEach(player =>
            {
                // todo load inventory,skills,quests
            });

            session.SetPlayer(playerList);

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
