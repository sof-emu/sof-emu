using Communicate.Logics;

namespace GameServer.Networks.Packets.Request
{
    public class RequestCheckName : ARecvPacket
    {
        protected string Name;

        public override void ExecuteRead()
        {
            Name = ReadS(15).Replace("\0", "");
        }

        public override void Process()
        {
            PlayerLogic.CheckName(session, Name);
        }
    }
}
