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
            // 0x0344
            Recv.Add(unchecked((short)0x0001), typeof(RequestAuth));
            Recv.Add(unchecked((short)0x0010), typeof(RequestPlayerList));
            Recv.Add(unchecked((short)0x0014), typeof(RequestCreatePlayer));
            Recv.Add(unchecked((short)0x0016), typeof(RequestSettingOption));
            Recv.Add(unchecked((short)0x00B0), typeof(RequestPing));
            Recv.Add(unchecked((short)0x0038), typeof(RequsetCheckName));
            Recv.Add(unchecked((short)0x0344), typeof(RequestVerifyLogin));
            Recv.Add(unchecked((short)0x1606), typeof(RequestVerifyVersion));

            Send.Add(typeof(ResponseAuth), unchecked((short)0x0002));
            Send.Add(typeof(ResponsePlayerList), unchecked((short)0x0011));
            Send.Add(typeof(ResponseCreatePlayer), unchecked((short)0x0015));
            Send.Add(typeof(ResponseCheckName), unchecked((short)0x0039));
            Send.Add(typeof(ResponseVerifyLogin), unchecked((short)0x0345));
            Send.Add(typeof(ResponseVerifyVersion), unchecked((short)0x2015));

            RecvNames = Recv.ToDictionary(p => p.Key, p => p.Value.Name);
            SendNames = Send.ToDictionary(p => p.Value, p => p.Key.Name);
        }
    }
}
