using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponsePlayerRunning : ASendPacket
    {
        protected int Running;

        public ResponsePlayerRunning(int running)
        {
            Running = running;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Running);
        }
    }
}
