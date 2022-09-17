using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseServerTime : ASendPacket
    {
        protected int Time;

        public ResponseServerTime(int time)
        {
            Time = time;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Time);
        }
    }
}
