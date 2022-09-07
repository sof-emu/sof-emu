using ApiServer.Models.Account;
using ApiServer.Models.Contracts.Databases;
using Dapper;

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
        public async Task<IEnumerable<AccountData>> GetAccounts()
        {
            var query = "SELECT * FROM account_data";
            using (var connection = _context.CreateConnection("account"))
            {
                var accounts = await connection.QueryAsync<AccountData>(query);
                return accounts.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AccountData> GetAccount(int id)
        {
            var query = "SELECT * FROM account_data WHERE id = @Id";
            using (var connection = _context.CreateConnection("account"))
            {
                var result = await connection.QuerySingleOrDefaultAsync<AccountData>(query, new { id });
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<AccountData> GetAccount(string username)
        {
            var query = "SELECT * FROM account_data WHERE username = @Username";
            using (var connection = _context.CreateConnection("account"))
            {
                var result = await connection.QuerySingleOrDefaultAsync<AccountData>(query, new { username });
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            var query = "SELECT COUNT(*) FROM account_data";
            using (var connection = _context.CreateConnection("account"))
            {
                var count = connection.ExecuteScalar<int>(query);
                return count;
            }
        }
    }
}
