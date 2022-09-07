using ApiServer.Models.Account;

namespace ApiServer.Models.Contracts.Databases
{
    public interface IAccountDataRepository
    {
        public Task<IEnumerable<AccountData>> GetAccounts();
        public Task<AccountData> GetAccount(int id);
        public Task<AccountData> GetAccount(string username);
        public int GetCount();
    }
}
