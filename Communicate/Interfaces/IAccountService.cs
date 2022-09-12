using Data.Interfaces;
using Data.Models.Account;

namespace Communicate.Interfaces
{
    public interface IAccountService : IComponent
    {
        void SetSettingOption(ISession session, SettingOption setting);
    }
}
