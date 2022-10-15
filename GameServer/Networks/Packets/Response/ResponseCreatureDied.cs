using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseCreatureDied : ASendPacket
    {
        protected Creature Creature;

        public ResponseCreatureDied(Creature creature)
        {
            Creature = creature;
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Seek(2, SeekOrigin.Begin);
            if (Creature is Player)
                WriteH(writer, (int)(Creature as Player).UID);
            else if (Creature is Npc)
                WriteH(writer, (int)(Creature as Npc).UID);
            writer.Seek(0, SeekOrigin.End);
        }
    }
}
