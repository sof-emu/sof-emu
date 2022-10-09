using Data.Structures.Account;
using Data.Structures.Player;
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
            WriteD(writer, (int)Player.UID);
            WriteSN(writer, Player.Name);

            WriteD(writer, 0); // Guild ID
            WriteSN(writer, string.Empty); // Guild Name
            WriteC(writer, 0);  //Guild Level
            WriteH(writer, 0); // Guild badge

            WriteC(writer, 0); // Neutral,Order,Chaos
            WriteC(writer, (byte)Player.Level);
            WriteC(writer, (byte)Player.JobLevel); // Job Level
            WriteC(writer, (byte)Player.Job);

            WriteC(writer, 0);

            WriteB(writer, Player.Appearance.HairColor.ToBytes()); // HairColor
            WriteH(writer, 1); // Hair Style
            WriteH(writer, 1); // Face Shape

            WriteH(writer, 0);
            WriteH(writer, 0);
            WriteH(writer, 0);

            WriteC(writer, (byte)Player.Appearance.Voice);
            WriteC(writer, (byte)Player.Appearance.Gender);

            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Z); // Flying = 270f
            WriteF(writer, Player.Position.Y);
            WriteD(writer, Player.Position.MapId);

            // var equips = Player.Inventory.EquipItems;

            WriteQ(writer, /*(equips[0] != null) ? equips[0].ItemId : */0); // Equip slot 0
            WriteQ(writer, /*(equips[1] != null) ? equips[1].ItemId : */ 0); // Equip slot 1
            WriteQ(writer, /*(equips[2] != null) ? equips[2].ItemId : */ 0); // Equip slot 2
            WriteQ(writer, /*(equips[4] != null) ? equips[4].ItemId : */ 0); // Equip slot 4
            WriteQ(writer, /*(equips[3] != null) ? equips[3].ItemId : */ 0); // Equip slot 3
            WriteQ(writer, /*(equips[5] != null) ? equips[5].ItemId : */ 0); // Equip slot 5
            WriteQ(writer, /*(equips[3] != null) ? equips[3].Upgrade : */ 0); // Equip slot 9
            WriteQ(writer, /*(equips[11] != null) ? equips[11].ItemId : */ 0); // Equip slot 10


            WriteC(writer, 0); // equipment slot 3 reinforcements
            WriteQ(writer, 0); // equipmeny slot 11 item id // 16900672

            int setting = SettingOption.GetSettings(Player.Session.GetSetting());
            Log.Debug($"Account Setting = {setting}");
            /*
            if (Player.AppendStatusList != null && Player.AppendStatusList.ContainsKey(700014))
			{
				setting += 8;
			}
			if (Play.walking state id1 == 1)
			{
				发包类.Write(setting + 1);
			}
			else if (Play.walking state id1 == 0)
			{
				发包类.Write(setting);
			}
             */
            WriteC(writer, 0); // todo
            WriteC(writer, 0); // todo with class passive skill
            WriteH(writer, 0); // Status of the luthier

            WriteF(writer, Player.Position.X);
            WriteF(writer, Player.Position.Z); // Flying = 270f
            WriteF(writer, Player.Position.Y);
            WriteD(writer, 0);

            WriteD(writer, 0xff); // PET Ride = 3 | Not Ride = 0, No pet = 255 (0xff)
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);

            WriteC(writer, 0);

            WriteD(writer, 0); // Wuxun in xwwl
            WriteD(writer, 0); // good and evil
            WriteH(writer, 0); 
            WriteH(writer, 0); // PK
            WriteD(writer, 0); // Buff VIP
            WriteD(writer, 0); // StealthMode

            WriteH(writer, 0); // Buff 1,20,8,6,0

            WriteB(writer, "0000000000000000FFFFFFFFFFFFFFFF0100000000000000FFFFFFFFFFFFFFFF0200000000000000FFFFFFFFFFFFFFFF");
            WriteC(writer, 0);
            WriteC(writer, 0); // Buff Fancy Weapon
            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0);

            
            WriteC(writer, 0); // Maried
            WriteSN(writer, ""); // Couple name
            WriteH(writer, 0); // Love Level

            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0);

            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0);

            WriteH(writer, 0);

            // map id 9001,9101,9201
            WriteD(writer, 0); // martial stage
            WriteH(writer, 0); // Honor ID

            WriteC(writer, 0); // Title Ranking

            WriteH(writer, 0); // Sect title type

            // todo write pet
            WriteC(writer, 0);
            for (int k = 0; k < 14; k++)
            {
                WriteD(writer, 0);
            }

            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0);

            WriteC(writer, 0); // Buff ??
            WriteH(writer, 0);
            WriteC(writer, 0);

            WriteC(writer, 0); // reinforcements == 15 items set
            WriteC(writer, 0);
            WriteC(writer, 0); // Buff item slot 3 reinforcements == 15
            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteD(writer, int.MaxValue);
            WriteH(writer, 0); // The power of the four gods

            int rngValue = Rng.Next(1, 2);
            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, 0);
            WriteC(writer, (byte)rngValue);
            WriteD(writer, 0); // equipment slot 15 item id
            WriteD(writer, 0);
            WriteD(writer, 0); // equipment slot 15 magic 1
            WriteD(writer, 0); // equipment slot 15 magic 2
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteD(writer, 0);
            WriteB(writer, new byte[32]);
            WriteC(writer, 0); // Flying mode
        }
    }
}
