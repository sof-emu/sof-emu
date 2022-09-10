using Data.Models.Account;
using System.IO;
using Utility;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseAuth : ASendPacket
    {
        protected AccountData AccountData;
        public ResponseAuth(AccountData accountData)
        {
            AccountData = accountData;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 1); // gender
            WriteH(writer, 0);

            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 9);
            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 0); //1

            WriteH(writer, 0);
            WriteH(writer, 14);
            WriteH(writer, 0);
            WriteH(writer, 1);
            WriteH(writer, 4369);
            WriteH(writer, 0);
            WriteH(writer, 4369);
            WriteH(writer, 0);
            WriteH(writer, 4369);

            WriteC(writer, 0xff);
            WriteC(writer, 0xff);

            WriteD(writer, 0);
            WriteD(writer, Funcs.GetRoundedLocal());
            WriteD(writer, 28);
            WriteB(writer, Funcs.NextBytes(4));
            WriteH(writer, 0x5041);
        }
    }
}
