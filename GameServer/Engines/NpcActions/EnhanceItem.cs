using Data.Interfaces;
using Data.Models.Npc;
using GameServer.Networks.Packets.Response;
using System;

namespace GameServer.Engines.NpcActions
{
    public class EnhanceItem : NpcAction
    {
        public override void Execute(ISession session, int shopId, int actionId, int tabIndex)
        {
            new ResponseNpcInteraction(shopId, actionId).Send(session);
        }
    }
}
