using Data.Structures.Account;
using SqlKata.Execution;
using System.Linq;

namespace LobbyServer.Database
{
    public class DbAccount
    {
        /// <summary>
        /// 
        /// </summary>
        protected QueryFactory _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public DbAccount(QueryFactory context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account GetAccountById(int id)
        {
            Account account = _context.Query("account_data")
                .Where("id", id)
                .FirstOrDefault<Account>();

            return account;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Account GetAccountByUsername(string username)
        {
            Account account = _context.Query("account_data")
                .Where("username", username)
                .FirstOrDefault<Account>();

            return account;
        }
    }
}
