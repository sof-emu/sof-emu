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
            // todo คำนวนหาน้ำหนักไอเทม

            WriteQ(writer, 999); // Money
            WriteD(writer, 0); // Current Weight
            WriteD(writer, 100); // Max Weight 
        }
    }
}
