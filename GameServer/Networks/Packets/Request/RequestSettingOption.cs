using Communicate;
using Data.Models.Player;
using GameServer.Services;
using Utility;

namespace GameServer.Networks.Packets.Request
{
    public class RequestSettingOption : ARecvPacket
    {
        protected int Partyable;
        protected int Tradeable;
        protected int CanWhisper;
        protected int CostumeType;
        protected int WeaponSwitch;
        protected int PetExp;
        protected int FameSwitch;
        protected int HairSwitch;
        protected int ConfestionSwitch;
        protected int SearchSwitch;
        protected int VegetableWeaponSwitch;
        protected int HonorRankEffect;

        protected int unk1;
        protected int unk2;

        public override void ExecuteRead()
        {
            // 01 01 01 01 01 00 00 63 01 01 01 01 64 00
            Partyable = ReadC();
            Tradeable = ReadC();
            CanWhisper = ReadC();

            unk1 = ReadC();

            CostumeType = ReadC();
            WeaponSwitch = ReadC();
            HairSwitch = ReadC();
            FameSwitch = ReadC();
            SearchSwitch = ReadC();
            ConfestionSwitch = ReadC();
            VegetableWeaponSwitch = ReadC();

            unk2 = ReadC();

            PetExp = ReadC();

            Log.Debug($"unk1 = {unk1}");
            Log.Debug($"unk2 = {unk2}");
        }

        public override void Process()
        {
            PlayerSetting setting = new PlayerSetting()
            {
                Partyable = Partyable,
                Tradeable = Tradeable,
                CanWhisper = CanWhisper,
                CostumeType = CostumeType,
                WeaponSwitch = WeaponSwitch,
                HairSwitch = HairSwitch,
                FameSwitch = FameSwitch,
                SearchSwitch = SearchSwitch,
                ConfestionSwitch = ConfestionSwitch,
                VegetableWeaponSwitch = VegetableWeaponSwitch,
                PetExp = PetExp,
            };

            Global
                .PlayerService
                .SetPlayerSetting(session, setting);
        }
    }
}
