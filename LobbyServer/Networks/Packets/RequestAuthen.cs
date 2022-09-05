using System;

namespace LobbyServer.Networks.Packets
{
    public class RequestAuthen : ARecvPacket
    {
        protected string Username;
        protected string Password;

        public override void ExecuteRead()
        {
            int nameLen = ReadH();
            Username = ReadS(nameLen);
            int pwdLen = ReadH();
            Password = ReadS(pwdLen);
        }

        public override void Process()
        {
            session
                .authService
                .Authenticate(Username, Password);
        }
    }
}
