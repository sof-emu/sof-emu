using Data.Structures.Npc;
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
            WriteD(writer, Npc.UID);
            WriteD(writer, 0);
        }
    }
}
