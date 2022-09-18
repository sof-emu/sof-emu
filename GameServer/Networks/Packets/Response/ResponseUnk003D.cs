using System.IO;
using Utility;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseUnk003D : ASendPacket
    {
        protected int Key;
        protected int Value;

        public ResponseUnk003D(int key, int val)
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
            /*
            WriteD(writer, Key);
            WriteH(writer, (byte)Value);
            WriteH(writer, 1);
            WriteH(writer, 1);
            WriteB(writer, new byte[18]);
            WriteD(writer, 1); // Current Active Skill Id
            */

            WriteB(writer, "0200000001000100000000000000000000000000000000000000000000000000".ToBytes());
        }
    }
}
