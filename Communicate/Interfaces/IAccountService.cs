using Data.Interfaces;
using Data.Structures.Account;

namespace Communicate.Interfaces
{
    public interface IAccountService : IComponent
    {
        void SetSettingOption(ISession session, SettingOption setting);
    }
}
