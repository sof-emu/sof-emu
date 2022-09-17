using Data.Models.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    internal class ResponseEquipInfo : ASendPacket
    {
        protected Player Player;

        public ResponseEquipInfo(Player p)
        {
            Player = p;
        }

        public override void Write(BinaryWriter writer)
        {
            for (int i = 0; i < 30; i++)
            {
                //if (Player.Inventory.EquipItems.ContainsKey(i) && i <= 15)
                //{
                //    var item = Player.Inventory.GetEquipItem(i);
                //    WriteItemInfo(writer, item);
                //}
                //else
                    WriteB(writer, new byte[88]);
            }

            writer.Seek(2, SeekOrigin.Begin);
            WriteH(writer, (int)Player.ObjectId);
            writer.Seek(0, SeekOrigin.End);
        }
    }
}
