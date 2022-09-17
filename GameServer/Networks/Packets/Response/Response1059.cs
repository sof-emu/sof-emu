using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class Response1059 : ASendPacket
    {
        public Response1059()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteQ(writer, 0);
        }
    }
}
