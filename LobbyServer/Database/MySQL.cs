using Data.Interfaces;
using LobbyServer.Configs;
using MySql.Data.MySqlClient;

namespace LobbyServer.Database
{
    public class MySQL
    {
        protected MySqlConnection Connection;

        public MySQL()
        {
            string connectionString = $"Server={Config.GetString("database", "host")};" +
                $"Port={Config.GetString("database", "port")};" +
                $"Database={Config.GetString("database", "database")};" +
                $"Uid={Config.GetString("database", "user")};" +
                $"Pwd={Config.GetString("database", "password")};";

            Connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Get mysql connection
        /// </summary>
        /// <returns></returns>
        public MySqlConnection GetConnection()
        {
            return Connection;
        }
    }
}
