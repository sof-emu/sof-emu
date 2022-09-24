using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseQuestCompleteList : ASendPacket
    {
        // protected List<Quest> QuestCompleteList;

        public ResponseQuestCompleteList()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            /*foreach(var quest in QuestCompleteList)
            {
                WriteH(writer, 0);
            }*/
        }
    }
}
