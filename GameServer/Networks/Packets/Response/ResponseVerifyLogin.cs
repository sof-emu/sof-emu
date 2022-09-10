using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseVerifyLogin : ASendPacket
    {
        protected int Unk1;
        protected int Unk2;
        protected string Username;

        public ResponseVerifyLogin(int unk1, int unk2, string username)
        {
            Unk1 = unk1;
            Unk2 = unk2;
            Username = username;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, Unk1);
            WriteH(writer, Unk2);
            WriteSL(writer, Username, 22);
            WriteD(writer, 0);
            WriteD(writer, 0);
        }
    }
}
