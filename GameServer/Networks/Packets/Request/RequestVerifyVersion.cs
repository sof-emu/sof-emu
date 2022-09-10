using GameServer.Networks.Packets.Response;

namespace GameServer.Networks.Packets.Request
{
    public class RequestVerifyVersion : ARecvPacket
    {
        public override void ExecuteRead()
        {
            
        }

        public override void Process()
        {
            new ResponseVerifyVersion()
                .Send(session);
        }
    }
}
