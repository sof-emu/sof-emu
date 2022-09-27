using Data.Interfaces;
using Data.Models.Npc;
using Data.Models.Player;

namespace Communicate.Interfaces
{
    public interface IFeedbackService : IComponent
    {
        void OnAuthorized(ISession session);
        void OnCreatePlayerResult(ISession session, Player player);
        void PlayerMoved(Player player, float x1, float y1, float z1, float x2, float y2, float z2, float distance, int tagert);
        void SelectNpc(ISession session, Npc npc);
        void SendServerTime(ISession session);
        void SendViewProfile(Player player);
    }
}
