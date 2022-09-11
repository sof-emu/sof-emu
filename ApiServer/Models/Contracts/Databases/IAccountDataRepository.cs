using Data.Models.Account;

namespace ApiServer.Models.Contracts.Databases
{
    public interface IAccountDataRepository
    {
        public IEnumerable<AccountData> GetAccounts();
        public AccountData GetAccount(int id);
        public AccountData GetAccount(string username);
        public int GetCount();
    }
}
