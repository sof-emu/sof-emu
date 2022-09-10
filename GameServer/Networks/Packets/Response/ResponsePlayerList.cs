using Data.Models.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponsePlayerList : ASendPacket
    {
        protected Player Player;

        public ResponsePlayerList()
        {
        }

        public ResponsePlayerList(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            if(Player == null)
            {
                WriteC(writer, 0xff);
            }
            else
            {
                WriteC(writer, (byte)Player.Index);
                WriteSN(writer, Player.Name);
                WriteC(writer, 0);
                WriteD(writer, 0);
                WriteSN(writer, "");
                WriteC(writer, 0);
                WriteH(writer, 0);

                WriteH(writer, 1);
                WriteH(writer, Player.Level);

                WriteC(writer, (byte)(Player.GetPlayerData().Force));
                WriteC(writer, 0); // famous
                WriteC(writer, (byte)(Player.Job));

                // Appearance
                WriteC(writer, (byte)(Player.GetPlayerData().HairStyle));
                WriteC(writer, (byte)(Player.GetPlayerData().HairColor));
                WriteC(writer, (byte)(Player.GetPlayerData().Face));
                WriteC(writer, (byte)(Player.GetPlayerData().Voice));
                WriteC(writer, 0);
                WriteC(writer, (byte)(Player.Title));
                WriteC(writer, (byte)(Player.GetPlayerData().Gender));

                WriteF(writer, Player.Position.X);
                WriteF(writer, Player.Position.Z);
                WriteF(writer, Player.Position.Y);
                WriteD(writer, Player.Position.MapId);

                WriteB(writer, new byte[12]); // UNK

                WriteB(writer, "0000000000000000FFFFFFFFFFFFFFFF0100000000000000FFFFFFFFFFFFFFFF0200000000000000FFFFFFFFFFFFFFFF");

                WriteB(writer, new byte[4]);
                WriteH(writer, 999); // Max HP
                WriteH(writer, 999); // Max MP
                WriteD(writer, 999); // Max SP
                WriteQ(writer, 1000); // Level up Exp

                WriteH(writer, 555); // Current HP
                WriteH(writer, 555); // Current MP
                WriteD(writer, 555); // Current SP
                WriteQ(writer, Player.Exp); // Current EXP

                WriteD(writer, 0);
                WriteB(writer, new byte[16]);

                // todo Write item
                //var Equiped = new List<object>();

                //foreach (var item in Equiped)
                //{
                //    WriteItemInfo(writer, null);
                //}
            }
        }
    }
}
