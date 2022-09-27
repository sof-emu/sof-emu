using Data.Interfaces;
using Data.Models.Npc;
using GameServer.Networks.Packets.Response;
using System.Collections.Generic;

namespace GameServer.Engines.NpcActions
{
    public class OpenShop : NpcAction
    {
        public override void Execute(ISession session, int shopId, int actionId, int tabIndex)
        {
            // todo load shoplist
            List<object> items = new List<object>();

            new ResponseNpcInteraction(shopId, actionId, tabIndex, items).Send(session);
        }
    }
}
