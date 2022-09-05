using Data.Interfaces;
using LobbyServer.Networks;
using LobbyServer.Networks.Packets;
using Utility;

namespace LobbyServer.Services
{
    public class AuthService : IService
    {
        protected Session session;

        public AuthService(Session sess)
        {
            session = sess;
        }

        public void Authenticate(string username, string password)
        {
            var account = Program.DBOManager.accountDBO.GetAccountByUsername(username);

            if (account == null)
            {
                // todo response account not found
            }

            string decryptPassword = password.DecryptPassword();
            if (account.Password != decryptPassword)
            {
                new ResponseAuthen(ResponseAuthenType.WrongPassword).Send(session);
            }

            // TODO response ok
        }
    }
}
