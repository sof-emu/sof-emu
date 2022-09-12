using Communicate;

namespace GameServer.Networks.Packets.Request
{
    public class RequestPlayerList : ARecvPacket
    {
        public override void ExecuteRead()
        {
            
        }

        public override void Process()
        {
            Global
                .PlayerService
                .SendPlayerLists(session);
        }
    }
}
