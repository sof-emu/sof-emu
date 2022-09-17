using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseQuestItem : ASendPacket
    {
        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 36);
            for (int i = 0; i < 36; i++)
            {
                WriteD(writer, i);
                WriteD(writer, 0);
                WriteD(writer, 0); // item id
                WriteD(writer, 0);
                WriteD(writer, 0); // count
            }
        }
    }
}
