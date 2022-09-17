using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseQuestList : ASendPacket
    {
        public ResponseQuestList()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 0); // Qeust Count
            /*foreach(var quest in QuestList)
            {
                WriteH(writer, quest.Id);
                WriteH(writer, quest.StageId);
            }*/
            WriteD(writer, 0);
        }
    }
}
