using Data.Interfaces;
using GameServer.Networks.Packets.Response;

namespace GameServer.Engines.NpcActions
{
    public class EndTalk : INpcAction
    {
        public void Execute(ISession session, int shopId, int actionId, int tabIndex)
        {
            // todo clear player Target

            new ResponseNpcInteraction(shopId, actionId).Send(session);
        }
    }
}
