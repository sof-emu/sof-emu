using Data.Structures.Npc;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseNpcSpawn : ASendPacket
    {
        protected List<Npc> Npcs;

        public ResponseNpcSpawn(List<Npc> npcs)
        {
            Npcs = npcs;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, Npcs.Count); // npc count

            foreach(var npc in Npcs)
            {
                WriteH(writer, npc.UID);
                WriteH(writer, npc.UID);

                WriteH(writer, npc.NpcId);

                WriteD(writer, 1);

                WriteD(writer, npc.LifeStats.Hp);
                WriteD(writer, npc.GameStats.HpBase);

                WriteF(writer, npc.Position.X);
                WriteF(writer, npc.Position.Z);
                WriteF(writer, npc.Position.Y);

                WriteD(writer, 0x40800000);

                WriteF(writer, npc.SpawnTemplate.Face1);
                WriteF(writer, npc.SpawnTemplate.Face2);

                WriteF(writer, npc.SpawnTemplate.X);
                WriteF(writer, npc.SpawnTemplate.Z);
                WriteF(writer, npc.SpawnTemplate.Y);

                WriteD(writer, 0);
                WriteD(writer, 0);
                WriteD(writer, 10);
                WriteD(writer, 0);
                WriteD(writer, 0x240000);
                WriteD(writer, int.MaxValue);
            }
            
            
        }
    }
}
