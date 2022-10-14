using Data.Enums;
using System;
using System.IO;
using System.Text;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseCheckName : ASendPacket
    {
        protected string Name;
        protected CheckNameResult Result;

        public ResponseCheckName(string name, CheckNameResult result)
        {
            Name = name;
            Result = result;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, (int)Result);

            byte[] names = new byte[16];
            byte[] temp = Encoding.Default.GetBytes(Name);
            Buffer.BlockCopy(temp, 0, names, 0, temp.Length);
            WriteB(writer, names);

            WriteD(writer, 0);
            WriteD(writer, 0);
        }
    }
}
