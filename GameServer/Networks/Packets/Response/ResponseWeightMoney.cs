using Data.Models.Player;
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

            WriteQ(writer, Player.GetInventory().Money); // Money
            WriteC(writer, 0);
            WriteD(writer, Player.GetInventory().TotalWeight); // Current Weight
            WriteD(writer, Player.GetInventory().MaxWeight); // Max Weight
        }
    }
}
