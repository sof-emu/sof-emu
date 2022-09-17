using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseSkillCooldown : ASendPacket
    {
        public ResponseSkillCooldown()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 1);
            WriteH(writer, 1);
            WriteH(writer, 0); // Skill Count

            /*
            foreach (武功类 value2 in World.TBL_KONGFU.Values)
            {
                if (base.Player_Job == value2.FLD_JOB || value2.FLD_JOB == 0)
                {
                    发包类.Write8(value2.FLD_PID);
                    发包类.Write8(0L);
                    发包类.Write8(0L);
                    发包类.Write8(0L);
                    发包类.Write8(value2.FLD_CDTIME);
                    发包类.Write8(0L);
                    发包类.Write8(0L);
                    发包类.Write4(0);
                }
            }
            */
        }
    }
}
