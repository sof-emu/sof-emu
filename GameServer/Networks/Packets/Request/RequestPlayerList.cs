namespace GameServer.Networks.Packets.Request
{
    public class RequestPlayerList : ARecvPacket
    {
        public override void ExecuteRead()
        {
            
        }

        public override void Process()
        {
            GameServer
                .PlayerService
                .SendPlayerLists(session);
        }
    }
}
