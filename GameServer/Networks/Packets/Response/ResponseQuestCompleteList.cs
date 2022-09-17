using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseQuestCompleteList : ASendPacket
    {
        public ResponseQuestCompleteList()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0);
        }
    }
}
