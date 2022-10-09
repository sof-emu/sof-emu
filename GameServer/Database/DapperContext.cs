using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace GameServer.Database
{
    public class DapperContext
    {
        public QueryFactory GetQueryFactory(string db_name)
        {
            var dbconfig = GameServer.Config["database"];

            var name = dbconfig.Configs["database"].GetString(db_name);
            var host = dbconfig.Configs["database"].GetString("host");
            var port = dbconfig.Configs["database"].GetString("port");
            var user = dbconfig.Configs["database"].GetString("user");
            var pass = dbconfig.Configs["database"].GetString("password");

            var connection = new MySqlConnection($"Server={host};" +
                $"Port={port};" +
                $"Database={name};" +
                $"Uid={user};" +
                $"Pwd={pass};");

            return new QueryFactory(connection, new MySqlCompiler());
        }
    }
}
