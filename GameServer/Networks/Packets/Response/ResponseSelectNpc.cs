using Data.Models.Npc;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseSelectNpc : ASendPacket
    {
        protected Npc Npc;
        public ResponseSelectNpc(Npc npc)
        {
            Npc = npc;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Npc.ObjectId);
            WriteD(writer, 0);
        }
    }
}
