using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace ApiServer.Database
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _dbSection;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbSection = _configuration.GetSection("Database");

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
        public QueryFactory GetQueryFactory(string dsn)
        {
            var name = _dbSection.GetSection(dsn).GetValue<string>("Name");
            var host = _dbSection.GetSection(dsn).GetValue<string>("Host");
            var port = _dbSection.GetSection(dsn).GetValue<string>("Port");
            var user = _dbSection.GetSection(dsn).GetValue<string>("User");
            var pass = _dbSection.GetSection(dsn).GetValue<string>("Password");

            var connection = new MySqlConnection($"Server={host};" +
                $"Port={port};" +
                $"Database={name};" +
                $"Uid={user};" +
                $"Pwd={pass};");

            return new QueryFactory(connection, new MySqlCompiler());
        }
    }
}
