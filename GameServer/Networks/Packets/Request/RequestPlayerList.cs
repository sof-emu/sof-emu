using Communicate;
using Communicate.Logics;

namespace GameServer.Networks.Packets.Request
{
    public class RequestPlayerList : ARecvPacket
    {
        public override void ExecuteRead()
        {
            
        }

        public override void Process()
        {
            AccountLogic.GetPlayerList(session);
        }
    }
}
