using Communicate.Logics;
using GameServer.Networks.Packets.Response;

namespace GameServer.Networks.Packets.Request
{
    public class RequestEnterworld : ARecvPacket
    {
        public override void ExecuteRead()
        {
            
        }

        public override void Process()
        {
            PlayerLogic.PlayerEnterWorld(session.Player);
            // new ResponseEnterWorld().Send(session);
        }
    }
}
