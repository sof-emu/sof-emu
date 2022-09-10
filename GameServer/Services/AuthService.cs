using Data.Interfaces;
using Data.Models.Account;
using GameServer.Networks;

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

            GameServer
                .FeedbackService
                .OnAuthorized(session);
        }
    }
}
