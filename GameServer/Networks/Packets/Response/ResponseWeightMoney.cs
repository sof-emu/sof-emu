using Data.Structures.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseWeightMoney : ASendPacket
    {
        protected Player Player;
        public ResponseWeightMoney(Player p)
        {
            Player = p;
        }

        public override void Write(BinaryWriter writer)
        {
            // todo calculate Total Weight
            // todo calculate Max Weight that player can carry
            // Total weight + Passive Skill + Player_Level * 6 * 96 + 4455000

            WriteQ(writer, 0); // Money
            WriteC(writer, 0);
            WriteD(writer, 0); // Current Weight
            WriteD(writer, 500); // Max Weight
        }
    }
}
