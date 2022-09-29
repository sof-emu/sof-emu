using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseDeletePlayer : ASendPacket
    {
        private bool result;
        private int index;

        public ResponseDeletePlayer(int index, bool result)
        {
            this.index = index;
            this.result = result;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, result ? 1 : 99);
            WriteD(writer, index); // index
            
            WriteD(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 6321);
        }
    }
}
