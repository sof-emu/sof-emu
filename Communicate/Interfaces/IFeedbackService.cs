using Data.Enums;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;

namespace Communicate.Interfaces
{
    public interface IFeedbackService : IComponent
    {
        void HpMpSpChanged(Player player);
        void OnAuthorized(ISession session);
        void OnPlayerEnterWorld(ISession session, Player player);
        void PlayerDied(Player player);
        void PlayerLevelUp(Player player);
        void PlayerMoved(Player player, float x1, float y1, float z1, float x2, float y2, float z2, float distance, int tagert);
        void SelectNpc(ISession session, Npc npc);
        void SendCheckNameResult(ISession session, string name, CheckNameResult result);
        void SendCreatePlayerResult(ISession session, bool v);
        void SendCreatureInfo(ISession session, Creature creature);
        void SendDeletePlayer(ISession session, int index, bool result);
        void SendInitailData(ISession session);
        void SendPlayerList(ISession connection);
        void SendRemoveCreature(ISession session, Creature creature);
        void SendServerTime(ISession session);
        void StatsUpdated(Player player);
    }
}
