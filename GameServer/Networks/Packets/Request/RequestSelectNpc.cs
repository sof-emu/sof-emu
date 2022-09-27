using Communicate.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Networks.Packets.Request
{
    public class RequestSelectNpc : ARecvPacket
    {
        protected int StatisticId;

        public override void ExecuteRead()
        {
            StatisticId = ReadD();
        }

        public override void Process()
        {
            PlayerLogic
                .SelectNpc(session, StatisticId);
        }
    }
}
