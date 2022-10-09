using LobbyServer.Configs;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace LobbyServer.Database
{
    public class DatabaseFactory
    {
        private QueryFactory context;

        public DbAccount DbAccount;

        public DatabaseFactory()
        {
            switch (Config.GetString("database", "dsn"))
            {
                case "mysql": context = new QueryFactory(new MySQL().GetConnection(), new MySqlCompiler()); break;
            }

            DbAccount = new DbAccount(context);
        }
    }
}
