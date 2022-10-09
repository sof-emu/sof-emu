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

        public void SetSettingOption(ISession session, SettingOption setting)
        {
            session
                .SetSetting(setting);
        }
    }
}
