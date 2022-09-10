using GameServer.Networks.Packets.Response;

namespace GameServer.Networks.Packets.Request
{
    public class RequestVerifyLogin : ARecvPacket
    {
        protected int Unk1; // Server ID ?
        protected int Unk2; // Channel ID ?
        protected string Username;

        public override void ExecuteRead()
        {
            Unk1 = ReadH();
            Unk2 = ReadH();
            Username = ReadS(22).Replace("\0", "");
        }

        public override void Process()
        {
            new ResponseVerifyLogin(Unk1, Unk2, Username).Send(session);
        }
    }
}
