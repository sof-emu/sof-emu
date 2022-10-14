using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace GameServer.Database
{
    public class DapperContext
    {
        public QueryFactory GetQueryFactory(string db_name)
        {
            var dbconfig = GameServer.Config["database"].Configs["database"];

            var name = dbconfig.GetString(db_name);
            var host = dbconfig.GetString("host");
            var port = dbconfig.GetString("port");
            var user = dbconfig.GetString("user");
            var pass = dbconfig.GetString("password");

            var connection = new MySqlConnection($"Server={host};" +
                $"Port={port};" +
                $"Database={name};" +
                $"Uid={user};" +
                $"Pwd={pass};");

            return new QueryFactory(connection, new MySqlCompiler());
        }
    }
}
