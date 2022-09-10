using GameServer.Networks.Packets.Request;
using GameServer.Networks.Packets.Response;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Networks
{
    public class OpCodes
    {
        public static Dictionary<short, Type> Recv = new Dictionary<short, Type>();
        public static Dictionary<Type, short> Send = new Dictionary<Type, short>();

        public static Dictionary<short, string> SendNames = new Dictionary<short, string>();

        public static void Init()
        {
            Recv.Add(unchecked((short)0x0001), typeof(RequestAuth));

            Send.Add(typeof(ResponseAuth), unchecked((short)0x0002));
        }
    }
}
