using Data.Structures.Npc;
using Data.Structures.SkillEngine;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseNpcAttack : ASendPacket
    {
        protected Npc Npc;
        protected Attack Attack;

        public ResponseNpcAttack(Npc npc, Attack attack)
        {
            Npc = npc;
            Attack = attack;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, Npc.Target.UID);
            WriteH(writer, 1);
            WriteH(writer, 0);
            WriteD(writer, Attack.Results[0]); // Damage 1
            WriteD(writer, Attack.Results[1]); // Damage 2
            WriteD(writer, Attack.Results[2]); // Damage 3
            WriteD(writer, Attack.Results[3]); // Damage 4
            WriteD(writer, Attack.Results[4]); // Damage 5
            WriteD(writer, 0); // Resilience
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, Attack.AttackAction);
            WriteF(writer, Npc.Position.X);
            WriteF(writer, Npc.Position.Z);
            WriteF(writer, Npc.Position.Y);
            WriteC(writer, 4);
            WriteC(writer, (byte)Attack.Count);
            WriteH(writer, 0);
            WriteD(writer, Npc.Target.LifeStats.Hp);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, -1);
            WriteB(writer, new byte[40]);
        }
    }
}
