using System.IO;
using Utility;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseVerifyVersion : ASendPacket
    {
        public ResponseVerifyVersion()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 4);
            WriteD(writer, 1904);

            byte[] bytes = "363233CB504728E9".ToBytes();
            WriteB(writer, bytes);

            WriteD(writer, 0);
            WriteD(writer, 0);
        }
    }
}
