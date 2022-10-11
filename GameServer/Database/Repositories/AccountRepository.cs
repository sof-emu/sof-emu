using Data.Interfaces.Database;
using Data.Structures.Account;
using SqlKata.Execution;
using System;
using System.Linq;
using Utility;

namespace GameServer.Database.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private QueryFactory DB;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        public AccountRepository(QueryFactory db)
        {
            DB = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Account GetAccountByUsername(string username)
        {
            try
            {
                var account = DB.Query("account_data")
                    .Where("username", username)
                    .FirstOrDefault<Account>();

                return account;
            }
            catch (Exception ex)
            {
                Log.ErrorException("GetAccountByUsername: ", ex);
                return null;
            }
        }
    }
}
