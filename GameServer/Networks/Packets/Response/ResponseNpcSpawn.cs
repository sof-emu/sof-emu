using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseNpcSpawn : ASendPacket
    {

        public ResponseNpcSpawn()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 0); // npc count

            /*
            WriteH(writer, (int)Npc.UID);
            WriteH(writer, (int)Npc.UID);

            WriteH(writer, Npc.NpcId);

            WriteD(writer, 1);

            WriteD(writer, Npc.LifeStats.Hp);
            WriteD(writer, Npc.MaxHp);

            WriteF(writer, Npc.Position.X);
            WriteF(writer, Npc.Position.Z);
            WriteF(writer, Npc.Position.Y);

            WriteD(writer, 0x40800000);

            WriteF(writer, Npc.SpawnTemplate.Face1);
            WriteF(writer, Npc.SpawnTemplate.Face2);

            WriteF(writer, Npc.Position.X);
            WriteF(writer, Npc.Position.Z);
            WriteF(writer, Npc.Position.Y);

            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0x0C);
            WriteD(writer, 0);
            */
        }
    }
}
