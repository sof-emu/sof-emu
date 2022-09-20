using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseSpiritBeast : ASendPacket
    {
        public ResponseSpiritBeast()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteQ(writer, 11);
        }
    }
}
