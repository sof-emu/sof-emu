using Data.Interfaces;
using Data.Models.Npc;
using GameServer.Networks.Packets.Response;
using System;

namespace GameServer.Engines.NpcActions
{
    public class MoveToMarketplace : NpcAction
    {
        public override void Execute(ISession session, int shopId, int actionId, int tabIndex)
        {
            new ResponseNpcInteraction(shopId, actionId).Send(session);
        }
    }
}
