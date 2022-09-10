using Data.Models.Account;
using System.IO;

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
            
        }
    }
}
