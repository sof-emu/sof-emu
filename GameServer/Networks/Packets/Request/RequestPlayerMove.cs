using Communicate.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Networks.Packets.Request
{
    public class RequestPlayerMove : ARecvPacket
    {
        protected float X1;
        protected float Y1;
        protected float Z1;

        protected float X2;
        protected float Y2;
        protected float Z2;

        protected int unk;
        protected float Distance;
        protected int Target;

        public override void ExecuteRead()
        {
            ReadD();

            X1 = ReadF();
            Z1 = ReadF();
            Y1 = ReadF();

            X2 = ReadF();
            Z2 = ReadF();
            Y2 = ReadF();

            unk = ReadD();
            Distance = ReadF();
            Target = ReadD();
        }

        public override void Process()
        {
            PlayerLogic.PlayerMoved(session.Player, X1, Y1, Z1, X2, Y2, Z2, Distance, Target);
        }
    }
}
