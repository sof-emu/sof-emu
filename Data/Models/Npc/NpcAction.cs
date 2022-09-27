using Data.Interfaces;

namespace Data.Models.Npc
{
    public abstract class NpcAction : INpcAction
    {
        public abstract void Execute(ISession session, int shopId, int actionId, int tabIndex);

        public void Process(ISession session, int shopId, int actionId, int tabIndex)
        {
            Execute(session, shopId, actionId, tabIndex);
        }
    }
}
