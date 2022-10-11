using Communicate;
using Communicate.Interfaces;
using Data.Interfaces;
using Data.Structures.Account;

namespace GameServer.Services
{
    public class AccountService : IAccountService
    {
        public void Action()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="username"></param>
        public void Authorized(ISession session, string username)
        {
            session.Account = Global.AccountRepository.GetAccountByUsername(username);
            session.Account.Players = Global.PlayerService.OnAuthorized(session.Account);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="setting"></param>
        public void SetSettingOption(ISession session, SettingOption setting)
        {
            session.Account.SettingOption = setting;
        }
    }
}
