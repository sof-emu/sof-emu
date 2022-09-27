using Communicate;

namespace GameServer.Networks.Packets.Request
{
    public class RequestNpcInteraction : ARecvPacket
    {
        protected int ActionId;
        protected int ShopId;
        protected int TabIndex;
        public override void ExecuteRead()
        {
            ActionId = ReadD(); // action id
            ReadD(); // 0
            ShopId = ReadD(); // store id
            ReadD(); // 0
            ReadD(); // 0
            TabIndex = ReadD(); // Tab
        }

        public override void Process()
        {
            Global
                .NpcService
                .NpcInteraction(session, ShopId, ActionId, TabIndex);
        }
    }
}
