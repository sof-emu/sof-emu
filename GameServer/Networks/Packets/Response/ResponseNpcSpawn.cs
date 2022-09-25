using Data.Models.Npc;
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
                WriteH(writer, npc.ObjectId);
                WriteH(writer, npc.ObjectId);

                WriteH(writer, npc.GetNpcTemplate().Id);

                WriteD(writer, 1);

                WriteD(writer, npc.GetLifeStats().Hp);
                WriteD(writer, npc.GetLifeStats().MaxHp);

                WriteF(writer, npc.GetSpawnTemplate().X);
                WriteF(writer, npc.GetSpawnTemplate().Z);
                WriteF(writer, npc.GetSpawnTemplate().Y);

                WriteD(writer, 0x40800000);

                WriteF(writer, npc.GetSpawnTemplate().Face1);
                WriteF(writer, npc.GetSpawnTemplate().Face2);

                WriteF(writer, npc.GetSpawnTemplate().X);
                WriteF(writer, npc.GetSpawnTemplate().Z);
                WriteF(writer, npc.GetSpawnTemplate().Y);

                WriteD(writer, 0);
                WriteD(writer, 0);
                WriteD(writer, 10);
                WriteD(writer, 0);
                WriteD(writer, 2359296);
                WriteD(writer, int.MaxValue);
            }
            
            
        }
    }
}
