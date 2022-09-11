using Data.Interfaces;
using LobbyServer.Networks;
using LobbyServer.Networks.Packets;
using Utility;

namespace LobbyServer.Services
{
    public class AuthService
    {
        public AuthService()
        {
        }

        public async void Authenticate(Session session, string username, string password)
        {
            var account = await LobbyServer
                .ApiService
                .RequestAccountData(username);

            if (account == null)
            {
                // todo response account not found
                new ResponseAuthen(ResponseAuthenType.WrongPassword).Send(session);
            }

            string decryptPassword = password.DecryptPassword();
            if (account.Password != decryptPassword)
            {
                new ResponseAuthen(ResponseAuthenType.WrongPassword).Send(session);
            }

            // TODO response ok
            new ResponseAuthen(ResponseAuthenType.Success).Send(session);
        }
    }
}
