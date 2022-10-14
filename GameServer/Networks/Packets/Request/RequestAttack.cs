using Communicate;
using Communicate.Logics;
using Data.Structures.Player;

namespace GameServer.Networks.Packets.Request
{
    public class RequestAttack : ARecvPacket
    {
        protected int targetId;
        protected UseSkillArgs Args = new UseSkillArgs();

        public override void ExecuteRead()
        {
            targetId = ReadH(); // target id
            ReadH(); // ?
            Args.SkillId = ReadD(); // skill id ?
            Args.TargetPosition.X = ReadF(); // x
            Args.TargetPosition.Z = ReadF(); // z
            Args.TargetPosition.Y = ReadF(); // y
            ReadD(); // 1 ?
        }

        public override void Process()
        {
            PlayerLogic.UseSkill(session, Args);

            // session.Player.Target = Global.VisibleService.FindTarget(session.Player, targetId);
            // Global.SkillEngine.UseSkill(session, Args);
        }
    }
}
