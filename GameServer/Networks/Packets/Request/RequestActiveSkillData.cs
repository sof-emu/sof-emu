using GameServer.Networks.Packets.Response;
using Utility;

namespace GameServer.Networks.Packets.Request
{
    public class RequestActiveSkillData : ARecvPacket
    {
        protected int Key;
        protected float X;
        protected float Y;
        protected float Z;

        public override void ExecuteRead()
        {
            Key = ReadD();
            ReadD();
            ReadD();

            X = ReadF();
            Z = ReadF();
            Y = ReadF();
        }

        public override void Process()
        {
            new ResponseActiveSkillData(Key, 1, 0).Send(session);
            //session.SendPacket("AA55260065003D002000020000000100010000000000000000000000000000000000000000000000000055AA".ToBytes());
        }
    }
}
