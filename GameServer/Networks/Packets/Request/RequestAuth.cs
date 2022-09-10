using System;

namespace GameServer.Networks.Packets.Request
{
    public class RequestAuth : ARecvPacket
    {
        protected int unk1;
        protected string username;

        public override void ExecuteRead()
        {
            unk1 = ReadH(); // 1
            username = ReadS(22);
        }

        public override void Process()
        {
            Program
                .AuthService
                .Authenticate(session, username);
        }
    }
}
