using Communicate.Logics;

namespace GameServer.Networks.Packets.Request
{
    public class RequestSelectNpc : ARecvPacket
    {
        protected int StatisticId;

        public override void ExecuteRead()
        {
            StatisticId = ReadD();
        }

        public override void Process()
        {
            PlayerLogic
                .SelectNpc(session, StatisticId);
        }
    }
}
