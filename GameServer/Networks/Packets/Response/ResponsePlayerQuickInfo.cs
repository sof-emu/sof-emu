using Data.Models.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponsePlayerQuickInfo : ASendPacket
    {
        protected Player Player;

        public ResponsePlayerQuickInfo(Player p)
        {
            Player = p;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 1);
            WriteD(writer, (int)Player.ObjectId);
            WriteSN(writer, Player.Name);
            WriteD(writer, 0);
            WriteH(writer, Player.Level);
            WriteC(writer, (byte)Player.JobLevel);
            WriteC(writer, (byte)Player.Job);
            WriteC(writer, 0); // Bs
            WriteC(writer, 0);

            for (int i = 0; i < 5; i++)
            {
                WriteB(writer, new byte[96]);
            }
        }
    }
}
