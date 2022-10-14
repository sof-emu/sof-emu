using Communicate.Logics;

namespace GameServer.Networks.Packets.Request
{
    public class RequestEnterWorld : ARecvPacket
    {
        protected int PlayerIndex;

        public override void ExecuteRead()
        {
            PlayerIndex = ReadC();
        }

        public override void Process()
        {
            PlayerLogic.PlayerSelected(session, PlayerIndex);
            PlayerLogic.PlayerEnterWorld(session.Player);
        }
    }
}
