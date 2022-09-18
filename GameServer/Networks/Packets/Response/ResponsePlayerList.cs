﻿using Data.Models.Player;
using System.IO;
using Utility;

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
                WriteB(writer, new byte[22]);
                //WriteSL(writer, "", 22); // Guild Name

                WriteH(writer, 0); // ZX
                WriteH(writer, Player.Level);
                WriteH(writer, Player.JobLevel);
                WriteC(writer, (byte)(Player.Job));

                // Appearance
                WriteC(writer, 1); // Unk1

                WriteB(writer, Player.HairColor.ToBytes());
                WriteC(writer, (byte)(Player.Face));
                WriteC(writer, (byte)(Player.Voice));

                WriteB(writer, new byte[8]);

                WriteC(writer, (byte)(Player.Title));
                WriteC(writer, (byte)(Player.Gender));

                WriteF(writer, Player.Position.X);
                WriteF(writer, Player.Position.Z);
                WriteF(writer, Player.Position.Y);
                WriteD(writer, Player.Position.MapId);

                WriteC(writer, 0); // Guild Flag
                WriteH(writer, 0); // Guild Flag Color

                WriteB(writer, new byte[9]); // UNK

                WriteB(writer, "0000000000000000FFFFFFFFFFFFFFFF0100000000000000FFFFFFFFFFFFFFFF0200000000000000FFFFFFFFFFFFFFFF");

                //WriteB(writer, new byte[4]);
                WriteH(writer, 205);
                WriteH(writer, 12651);
                WriteH(writer, 1642);
                WriteH(writer, 1160);
                WriteH(writer, 1000);
                WriteH(writer, 0);
                WriteH(writer, 20406);
                WriteH(writer, 6213);
                WriteD(writer, 0);



                //WriteH(writer, 999); // Max HP
                //WriteH(writer, 999); // Max MP
                //WriteD(writer, 999); // Max SP
                //WriteQ(writer, 1000); // Level up Exp

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

            // byte[] aa = "006D656C6C6F0000000000000000000000000000000000000000000000000000000000000000000000230000000801DFFF000000000000000000000101FF42D343000070410461C144650000000000000000000000000000000000000000000000FFFFFFFFFFFFFFFF0100000000000000FFFFFFFFFFFFFFFF0200000000000000FFFFFFFFFFFFFFFFCD006B316A068804E8030000B64F4518000000002902740000000000A963CB130000000000F0180000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000020000000000000000000000000000002C0F6F04".ToBytes();
            // WriteB(writer, aa);
        }
    }
}
