using Data.Models.Account;
using Data.Models.Player;
using System.IO;
using Utility;

namespace GameServer.Networks.Packets.Response
{
    public class ResponsePlayerInfo : ASendPacket
    {
        protected Player Player;

        public ResponsePlayerInfo(Player p)
        {
            Player = p;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 1);

            WriteD(writer, (int)Player.GetSession().SessionId);
            WriteSN(writer, Player.Name);
            WriteC(writer, 0);

            WriteD(writer, 0); // Guild ID
            WriteSN(writer, string.Empty); // Guild Name
            WriteC(writer, 0);  //Guild Level

            WriteH(writer, 0); // SERVER ID ?

            WriteC(writer, (byte)Player.Force);
            WriteC(writer, (byte)Player.Level);
            WriteC(writer, (byte)Player.JobLevel); // Job Level
            WriteC(writer, (byte)Player.Job);

            WriteC(writer, 1);
            WriteC(writer, 0);

            WriteB(writer, Player.HairColor.ToBytes());
            WriteC(writer, 1);
            WriteC(writer, (byte)Player.Gender);

            WriteH(writer, 0);

            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Z);
            WriteF(writer, Player.Position.Y);
            WriteD(writer, Player.Position.MapId);

            // var equips = Player.Inventory.EquipItems;

            WriteQ(writer, /*(equips[0] != null) ? equips[0].ItemId : */0); // Equip slot 0
            WriteQ(writer, /*(equips[1] != null) ? equips[1].ItemId : */ 0); // Equip slot 1
            WriteQ(writer, /*(equips[2] != null) ? equips[2].ItemId : */ 0); // Equip slot 2
            WriteQ(writer, /*(equips[4] != null) ? equips[4].ItemId : */ 0); // Equip slot 4
            WriteQ(writer, /*(equips[3] != null) ? equips[3].ItemId : */ 0); // Equip slot 3
            WriteQ(writer, /*(equips[5] != null) ? equips[5].ItemId : */ 0); // Equip slot 5
            WriteD(writer, /*(equips[3] != null) ? equips[3].Upgrade : */ 0); // Equip slot 3 LevelUpgrade
            WriteQ(writer, /*(equips[11] != null) ? equips[11].ItemId : */ 0); // Equip slot 11

            int setting = SettingOption.GetSettings(Player.GetSession().GetSetting());
            WriteC(writer, (byte)setting);
            WriteC(writer, (byte)(Player.GetSession().GetSetting().Fame));
            WriteH(writer, 0);

            WriteF(writer, Player.LastPostion.X);
            WriteF(writer, Player.LastPostion.Z);
            WriteF(writer, Player.LastPostion.Y);

            WriteD(writer, 0);
            WriteD(writer, 0);

            WriteD(writer, 0xff); // PET
            WriteD(writer, 0);
            WriteQ(writer, /*(equips[13] != null) ? equips[13].ItemId : */0); //  Equip slot 13

            WriteH(writer, 0); // Word gang door service
            WriteH(writer, 0); // Gang colors door service

            WriteD(writer, 0); // Player_WuXun fame point
            WriteD(writer, 1); // Force side

            WriteD(writer, 0); // People head picture
            WriteD(writer, 0); // StealthMode

            WriteB(writer, "0000000000000000FFFFFFFFFFFFFFFF0100000000000000FFFFFFFFFFFFFFFF0200000000000000FFFFFFFFFFFFFFFF");

            WriteD(writer, 1);

            // Maried
            WriteC(writer, 0);
            WriteSN(writer, "");

            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 0);

            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0);

            WriteH(writer, 0);
        }
    }
}
