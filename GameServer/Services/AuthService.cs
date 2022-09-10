using Data.Interfaces;
using Data.Models.Account;
using GameServer.Networks;

namespace GameServer.Services
{
    public class AuthService : IService
    {
        public async void Authenticate(Session session, string username)
        {
            AccountData accountData = await Program
                .ApiService
                .RequestAccountData(username);

            if (accountData == null)
                return;


        }
    }
}
