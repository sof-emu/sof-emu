using ApiServer.Models.Contracts.Databases;
using Data.Models.Account;
using SqlKata.Execution;

namespace ApiServer.Database.Repository
{
    public class AccountDataRepository : IAccountDataRepository
    {
        private readonly DapperContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AccountDataRepository(DapperContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All AccountData in tables
        /// </summary>
        /// <returns>List of account data</returns>
        public IEnumerable<AccountData> GetAccounts()
        {
            using (var db = _context.GetQueryFactory("account"))
            {
                var accounts = db.Query("account_data").Get<AccountData>();
                return accounts;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AccountData GetAccount(int id)
        {
            using (var db = _context.GetQueryFactory("account"))
            {
                var result = db.Query("account_data")
                    .Where("id", id)
                    .FirstOrDefault<AccountData>();

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public AccountData GetAccount(string username)
        {
            using (var db = _context.GetQueryFactory("account"))
            {
                var result = db.Query("account_data")
                    .Where("username", username)
                    .FirstOrDefault<AccountData>();

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            using (var db = _context.GetQueryFactory("account"))
            {
                var count = db.Query("account_data")
                    .Get()
                    .Count();

                return count;
            }
        }
    }
}
