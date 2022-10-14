using Data.Interfaces;
using Data.Structures.Account;

namespace Communicate.Interfaces
{
    public interface IAccountService : IComponent
    {
        void Authorized(ISession session, string username);
        void SetSettingOption(ISession session, SettingOption setting);
    }
}
