using Data.Interfaces;
using Data.Models.Player;

namespace Communicate.Interfaces
{
    public interface IFeedbackService : IComponent
    {
        void OnAuthorized(ISession session);
        void OnCreatePlayerResult(ISession session, Player player);
    }
}
