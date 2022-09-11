using Data.Models.Account;
using Data.Models.Player;

namespace Data.Interfaces
{
    public interface IPlayer
    {
        void SetAccount(AccountData acc);
        AccountData GetAccount();
        void SetSession(ISession session);
        ISession GetSession();
        void SetSetting(PlayerSetting setting);
        PlayerSetting GetSetting();
    }
}
