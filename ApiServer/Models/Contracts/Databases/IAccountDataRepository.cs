using Data.Structures.Account;

namespace ApiServer.Models.Contracts.Databases
{
    public interface IAccountDataRepository
    {
        public IEnumerable<Account> GetAccounts();
        public Account GetAccount(int id);
        public Account GetAccount(string username);
        public int GetCount();
    }
}
