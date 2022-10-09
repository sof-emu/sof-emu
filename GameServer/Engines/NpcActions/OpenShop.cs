using Data.Interfaces;
using Data.Structures.Template.Item;
using GameServer.Networks.Packets.Response;
using System.Collections.Generic;

namespace GameServer.Engines.NpcActions
{
    public class OpenShop : INpcAction
    {
        public void Execute(ISession session, int shopId, int actionId, int tabIndex)
        {
            // todo load shoplist
            List<ShopItemTemplate> items = Data.Data
                .ShopItemsTemplates[shopId];

            new ResponseNpcInteraction(shopId, actionId, tabIndex, items)
                .Send(session);
        }
    }
}
