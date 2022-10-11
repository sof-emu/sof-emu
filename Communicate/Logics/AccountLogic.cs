using Data.Interfaces;

namespace Communicate.Logics
{
    public class AccountLogic : Global
    {
        public static void TryAuthorize(ISession session, string username, string ip, string mac)
        {
            AccountService.Authorized(session, username);
            FeedbackService.OnAuthorized(session);
        }
    }
}
