using Communicate.Logics;
using Data.Models.Player;
using Data.Models.World;

namespace GameServer.Networks.Packets.Request
{
    public class RequestAttack : ARecvPacket
    {
        protected int targetId;
        protected int skillId;
        protected float x;
        protected float y;
        protected float z;
        protected Position pos = new Position();
        protected int unk1;

        public override void ExecuteRead()
        {
            targetId = ReadH(); // target id
            ReadH(); // ?
            skillId = ReadD(); // skill id ?
            pos.X = ReadF(); // x
            pos.Z = ReadF(); // z
            pos.Y = ReadF(); // y
            ReadD(); // 1 ?
        }

        public override void Process()
        {
            Player player = session.GetSelectedPlayer();
            GlobalLogic
                .AttackTarget(player, targetId, skillId, pos, unk1);
        }
    }
}
