using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseBindPoint : ASendPacket
    {
        public ResponseBindPoint()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0);
        }
    }
}
