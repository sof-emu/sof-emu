using LobbyServer.Networks.Packets;
using System;
using System.Collections.Generic;

namespace LobbyServer.Networks
{
    public class OpCodes
    {
        public static Dictionary<short, Type> Recv = new Dictionary<short, Type>();
        public static Dictionary<Type, short> Send = new Dictionary<Type, short>();

        public static Dictionary<short, string> SendNames = new Dictionary<short, string>();

        public static void Init()
        {
            Recv.Add(unchecked((short)0x8000), typeof(RequestAuthen));
            // Recv.Add(unchecked((short)0x8016), typeof(RequestServerList));
            // Recv.Add(unchecked((short)0x800C), typeof(RequestSelectServer));


            // Send.Add(typeof(ResponseLogin), unchecked((short)0x8001));
            // Send.Add(typeof(ResponseServerList), unchecked((short)0x8017));
            // Send.Add(typeof(ResponseSelectServer), unchecked((short)0x8064));
        }
    }
}
