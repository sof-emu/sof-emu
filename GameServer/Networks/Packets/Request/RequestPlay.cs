using Communicate.Logics;
using GameServer.Networks.Packets.Response;

namespace GameServer.Networks.Packets.Request
{
    public class RequestPlay : ARecvPacket
    {
        public override void ExecuteRead()
        {
            
        }

        public override void Process()
        {
            new ResponseEnteringWorld().Send(session);
        }
    }
}
