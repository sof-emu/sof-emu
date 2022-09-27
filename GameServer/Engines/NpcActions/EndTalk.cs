using Data.Interfaces;
using Data.Models.Npc;
using GameServer.Networks.Packets.Response;

namespace GameServer.Engines.NpcActions
{
    public class EndTalk : NpcAction
    {
        public override void Execute(ISession session, int shopId, int actionId, int tabIndex)
        {
            // todo clear player Target

            new ResponseNpcInteraction(shopId, actionId).Send(session);
        }
    }
}
