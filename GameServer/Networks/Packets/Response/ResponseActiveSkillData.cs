using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseActiveSkillData : ASendPacket
    {
        protected int Key;
        protected int Value;

        public ResponseActiveSkillData(int key, int val)
        {
            Key = key;
            Value = val;
        }

        public override void Write(BinaryWriter writer)
        {
            // 02000000
            // 0100
            // 0100
            // 000000000000000000000000000000000000000000000000
            
            WriteD(writer, Key); // skill id
            WriteC(writer, (byte)Value);
            WriteC(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteB(writer, new byte[14]);
            WriteD(writer, Key);
            WriteD(writer, Value); // Current Active Skill Id
            WriteD(writer, 0);
            WriteD(writer, 0);

            // WriteB(writer, "0200000001000100000000000000000000000000000000000000000000000000".ToBytes());
        }
    }
}
