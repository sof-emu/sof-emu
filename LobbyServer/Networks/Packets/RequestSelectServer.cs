namespace LobbyServer.Networks.Packets
{
    public class RequestSelectServer : ARecvPacket
    {
        protected int serverId;
        protected int channelId;
        protected int unk1;
        protected string macAddress;
        public override void ExecuteRead()
        {
            serverId = ReadD();
            channelId = ReadD();
            unk1 = ReadC();
            macAddress = ReadS();
        }

        public override void Process()
        {
            LobbyServer
                .BroadcastService
                .SelectServerList(
                    session,
                    serverId,
                    channelId,
                    macAddress
                );
        }
    }
}