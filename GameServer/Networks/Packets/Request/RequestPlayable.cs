using GameServer.Networks.Packets.Response;

namespace GameServer.Networks.Packets.Request
{
    public class RequestPlayable : ARecvPacket
    {
        public override void ExecuteRead()
        {
            
        }

        public override void Process()
        {
            new ResponsePlayable().Send(session);
        }
    }
}
