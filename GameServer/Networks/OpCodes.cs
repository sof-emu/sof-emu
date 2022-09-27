using GameServer.Networks.Packets.Request;
using GameServer.Networks.Packets.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Networks
{
    public class OpCodes
    {
        public static Dictionary<short, Type> Recv = new Dictionary<short, Type>();
        public static Dictionary<Type, short> Send = new Dictionary<Type, short>();

        public static Dictionary<short, string> RecvNames = new Dictionary<short, string>();
        public static Dictionary<short, string> SendNames = new Dictionary<short, string>();

        public static void Init()
        {
            Recv.Add(unchecked((short)0x0001), typeof(RequestAuth));
            Recv.Add(unchecked((short)0x0005), typeof(RequestEnterWorld));
            Recv.Add(unchecked((short)0x0007), typeof(RequestPlayerMove));
            Recv.Add(unchecked((short)0x0010), typeof(RequestPlayerList));
            Recv.Add(unchecked((short)0x0014), typeof(RequestCreatePlayer));
            Recv.Add(unchecked((short)0x0016), typeof(RequestSettingOption));
            Recv.Add(unchecked((short)0x001E), typeof(RequestDeletePlayer));
            Recv.Add(unchecked((short)0x00B0), typeof(RequestPing));
            Recv.Add(unchecked((short)0x0038), typeof(RequsetCheckName));
            Recv.Add(unchecked((short)0x003C), typeof(RequestActiveSkillData));
            Recv.Add(unchecked((short)0x008F), typeof(RequestPlayable));
            Recv.Add(unchecked((short)0x0090), typeof(RequestNpcInteraction));
            Recv.Add(unchecked((short)0x00B5), typeof(RequestViewProfile));
            Recv.Add(unchecked((short)0x0344), typeof(RequestVerifyLogin));
            Recv.Add(unchecked((short)0x1088), typeof(RequestSelectNpc));
            Recv.Add(unchecked((short)0x1606), typeof(RequestVerifyVersion));

            Send.Add(typeof(ResponseAuth), unchecked((short)0x0002));
            Send.Add(typeof(ResponsePlayerRunning), unchecked((short)0x0006));
            Send.Add(typeof(ResponsePlayerList), unchecked((short)0x0011));
            Send.Add(typeof(ResponseCreatePlayer), unchecked((short)0x0015));
            Send.Add(typeof(ResponsePlayable), unchecked((short)0x0020));
            Send.Add(typeof(ResponseCheckName), unchecked((short)0x0039));
            Send.Add(typeof(ResponseActiveSkillData), unchecked((short)0x003D));
            Send.Add(typeof(ResponsePlayerInfo), unchecked((short)0x0064));
            Send.Add(typeof(ResponsePlayerMove), unchecked((short)0x0065));
            Send.Add(typeof(ResponseNpcSpawn), unchecked((short)0x0067));
            Send.Add(typeof(ResponsePlayerHpMpSp), unchecked((short)0x0069));
            Send.Add(typeof(ResponseSkillPassive), unchecked((short)0x006C));
            Send.Add(typeof(ResponseInventoryInfo), unchecked((short)0x0071));
            Send.Add(typeof(ResponseEquipInfo), unchecked((short)0x0076));
            Send.Add(typeof(ResponseWeightMoney), unchecked((short)0x007C));
            Send.Add(typeof(ResponseServerTime), unchecked((short)0x0080));
            Send.Add(typeof(ResponseQuestItem), unchecked((short)0x0081));
            Send.Add(typeof(ResponseQuestList), unchecked((short)0x0085));
            Send.Add(typeof(ResponseStatusEffect), unchecked((short)0x0087));
            Send.Add(typeof(ResponseQuestCompleteList), unchecked((short)0x008B));
            Send.Add(typeof(ResponseNpcInteraction), unchecked((short)0x0091));
            Send.Add(typeof(ResponsePlayerQuickInfo), unchecked((short)0x00A0));
            Send.Add(typeof(ResponseViewProfile), unchecked((short)0x00B2));
            Send.Add(typeof(ResponseSkillCooldown), unchecked((short)0x0212));
            Send.Add(typeof(ResponseVerifyLogin), unchecked((short)0x0345));
            Send.Add(typeof(ResponseBindPoint), unchecked((short)0x100B));
            Send.Add(typeof(ResponsePetInfo), unchecked((short)0x1059));
            Send.Add(typeof(ResponseSelectNpc), unchecked((short)0x1089));
            Send.Add(typeof(ResponseDeletePlayer), unchecked((short)0x1F00));
            Send.Add(typeof(ResponseVerifyVersion), unchecked((short)0x2015));

            RecvNames = Recv.ToDictionary(p => p.Key, p => p.Value.Name);
            SendNames = Send.ToDictionary(p => p.Value, p => p.Key.Name);
        }
    }
}
