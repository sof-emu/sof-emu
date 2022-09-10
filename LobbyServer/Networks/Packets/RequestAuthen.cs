using System;

namespace LobbyServer.Networks.Packets
{
    public class RequestAuthen : ARecvPacket
    {
        protected string Username;
        protected string Password;

        public override void ExecuteRead()
        {
            Username = ReadS();
            Password = ReadS();
        }

        public override void Process()
        {
            LobbyServer
                .AuthService
                .Authenticate(session, Username, Password);
        }
    }
}
