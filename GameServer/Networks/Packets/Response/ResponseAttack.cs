using Data.Models.Player;
using Data.Models.SkillEngine;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseAttack : ASendPacket
    {
        protected Player Player;
        protected Attack Attack;

        public ResponseAttack(Player player, Attack attack)
        {
            Player = player;
            Attack = attack;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, Player.GetTarget().ObjectId);
            WriteH(writer, 1);
            WriteH(writer, Attack.Args.SkillId);

            WriteD(writer, Attack.Results[0]); // damage 1
            WriteD(writer, Attack.Results[1]); // damage 2
            WriteD(writer, Attack.Results[2]); // damage 3
            WriteD(writer, Attack.Results[3]); // damage 4
            WriteD(writer, Attack.Results[4]); // damage 5

            WriteD(writer, 0); // Barrier absorption
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);

            WriteD(writer, Attack.Args.SkillId);
            WriteD(writer, Attack.AttackAction); // skill effect

            WriteF(writer, Attack.Args.TargetPosition.X);
            WriteF(writer, Attack.Args.TargetPosition.Z);
            WriteF(writer, Attack.Args.TargetPosition.Y);

            WriteC(writer, 0); // wugong type
            WriteC(writer, 1); // Attack Count
            WriteC(writer, 0);
            WriteD(writer, Player.GetTarget().GetLifeStats().Hp); // hp

            WriteD(writer, 0); // Fail Status 1,2,3
            WriteC(writer, 0);

            if(Player.GetTarget().ObjectId > 10000)
            {
                // if(petAttack != -1) {
                //  if(Funcs.IsLuck(80)) {
                //      WriteD(writer, petAttack);
                //  } else
                //      WriteD(writer, 0);
                // }
            }
            else
                WriteD(writer, -1);

            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);

            WriteD(writer, 0);
        }
    }
}
