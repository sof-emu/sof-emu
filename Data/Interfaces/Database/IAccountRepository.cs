using Data.Structures.Account;

namespace Data.Interfaces.Database
{
    public interface IAccountRepository
    {
        Account GetAccountByUsername(string username);
    }
}
