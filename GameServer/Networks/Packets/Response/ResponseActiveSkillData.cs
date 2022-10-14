using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseActiveSkillData : ASendPacket
    {
        protected int SpellId;
        protected byte Command;
        protected byte SpellLevel;

        public ResponseActiveSkillData(int spellId, byte cmd, byte spelllvl)
        {
            SpellId = spellId;
            Command = cmd;
            SpellLevel = spelllvl;
        }

        public override void Write(BinaryWriter writer)
        {
            // 02000000
            // 0100
            // 0100
            // 000000000000000000000000000000000000000000000000
            
            WriteD(writer, SpellId); // skill id
            WriteH(writer, Command);
            WriteH(writer, SpellLevel);
            WriteH(writer, 0);
            WriteB(writer, new byte[14]);
            WriteD(writer, 0);
            WriteD(writer, 0); // Current Active Skill Id
            WriteD(writer, 0);
            WriteD(writer, 0);

            // WriteB(writer, "0200000001000100000000000000000000000000000000000000000000000000".ToBytes());
        }
    }
}
