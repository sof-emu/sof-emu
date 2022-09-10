using Data.Interfaces;
using Data.Models.Account;
using GameServer.Networks;
using GameServer.Networks.Packets.Response;

namespace GameServer.Services
{
    public class AuthService : IService
    {
        public async void Authenticate(Session session, string username)
        {
            AccountData accountData = await GameServer
                .ApiService
                .RequestAccountData(username);

            if (accountData == null)
                return;

            // todo send Auth Response

            new ResponseAuth(accountData).Send(session);
        }
    }
}
