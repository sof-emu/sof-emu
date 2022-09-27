using Communicate.Logics;
using Utility;

namespace GameServer.Networks.Packets.Request
{
    public class RequestDeletePlayer : ARecvPacket
    {
        protected int SessionId;
        protected int Index;
        protected string Password;

        public override void ExecuteRead()
        {
            ReadD();
            SessionId = ReadD(); // Session Id?
            Index = ReadD(); // index ?
            Password = ReadS(32); // md5 password
        }

        public override void Process()
        {
            Log.Debug($"SessionId: {SessionId}, Index: {Index}, Password: {Password}");
            // todo delete player
            PlayerLogic
                .DeletePlayer(session, Index, Password);
        }
    }
}
