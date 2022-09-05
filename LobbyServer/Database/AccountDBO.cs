using Dapper;
using Data.Interfaces;
using Data.Models.Account;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobbyServer.Database
{
    public class AccountDBO
    {
        MySqlConnection Connection;

        public AccountDBO(MySqlConnection connection)
        {
            Connection = connection;
        }

        public AccountData GetAccountById(int id)
        {
            AccountData accountData = Connection.QueryFirst<AccountData>(
                "select * from account_data where id = @id",
                new { id = id }
            );

            return accountData;
        }

        public AccountData GetAccountByUsername(string username)
        {
            AccountData accountData = Connection.QueryFirst<AccountData>(
                "select * from account_data where username = @username",
                new { username = username }
            );

            return accountData;
        }
    }
}
