﻿using System;

namespace LobbyServer.Networks.Packets
{
    public class RequestServerList : ARecvPacket
    {
        public override void ExecuteRead()
        {
        }

        public override void Process()
        {
            Program
                .BroadcastService
                .SendServerList(session);
        }
    }
}