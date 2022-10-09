using Data.Structures.Player;
using System.IO;
using Utility;

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
            WriteD(writer, (int)Player.UID);
            WriteSN(writer, Player.Name);

            WriteD(writer, 0); // Guild ID
            WriteSN(writer, string.Empty); // Guild Name
            WriteC(writer, 0);  //Guild Level
            WriteH(writer, 0); // Guild badge

            WriteC(writer, 0);

            WriteH(writer, 0); // Faction Neutral,Order,Chaos
            WriteH(writer, Player.Level);
            WriteC(writer, (byte)Player.JobLevel);
            WriteC(writer, 0);
            WriteC(writer, (byte)Player.Job);
            WriteC(writer, 1);

            WriteB(writer, Player.Appearance.HairColor.ToBytes()); // HairColor
            WriteH(writer, 0); // Hair Style
            WriteH(writer, 0); // Face Shape

            WriteC(writer, (byte)Player.Appearance.Voice);
            WriteC(writer, (byte)Player.Appearance.Gender);

            WriteD(writer, 0);
            WriteC(writer, 1);
            WriteC(writer, 2);

            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Z); // Flying = 270f
            WriteF(writer, Player.Position.Y);
            WriteD(writer, Player.Position.MapId);

            WriteQ(writer, 0);

            //WriteB(writer, "0000000000000000FFFFFFFFFFFFFFFF0100000000000000FFFFFFFFFFFFFFFF0200000000000000FFFFFFFFFFFFFFFF");
            WriteQ(writer, 0);
            WriteQ(writer, 0);
            WriteQ(writer, 1);
            WriteQ(writer, 0);
            WriteQ(writer, 2);
            WriteQ(writer, 0);

            WriteD(writer, -1);

            // Equipment slot
            for (int i = 0; i < 15; i++)
            {
                WriteB(writer, new byte[96]);
            }

            // Auxiliary equipment slot
            for (int i = 0; i < 15; i++)
            {
                WriteB(writer, new byte[96]);
            }

            WriteB(writer, new byte[96]); // equipment slot 15

            WriteB(writer, new byte[288]);

            // Orb Equipment Slot
            // order slot i[0] = slot[3],
            // i[1] = slot[5]
            // i[2] = slot[4]
            // i[3] = slot[1]
            // i[4] = slot[2]
            // i[5] = slot[0]
            for (int i = 0; i < 6; i++)
            {
                WriteB(writer, new byte[96]);
            }

            WriteB(writer, new byte[9]);

            //writer.Seek(2, SeekOrigin.Begin);
            //WriteH(writer, (int)Player.GetSession().SessionId);
            //writer.Seek(0, SeekOrigin.End);
        }
    }
}
