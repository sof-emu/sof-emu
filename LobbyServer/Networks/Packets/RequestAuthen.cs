using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyServer.Networks.Packets
{
    public class RequestAuthen : ARecvPacket
    {
        protected string Username;
        protected string Password;

        public override void Read()
        {
            Username = ReadS();
            Password = ReadS();
        }

        public override void Process()
        {
            
        }
    }
}
