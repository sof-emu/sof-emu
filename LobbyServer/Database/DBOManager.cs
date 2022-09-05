using Data.Interfaces;
using LobbyServer.Configs;
using MySql.Data.MySqlClient;

namespace LobbyServer.Database
{
    public class DBOManager
    {
        private MySqlConnection connection;

        public AccountDBO accountDBO;

        public DBOManager()
        {
            switch (Config.GetString("database", "dsn"))
            {
                case "mysql": connection = new MySQL().GetConnection(); break;
            }

            accountDBO = new AccountDBO(connection);
        }
    }
}
