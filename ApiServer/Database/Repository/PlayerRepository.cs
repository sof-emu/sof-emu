using ApiServer.Models.Contracts.Databases;
using Dapper;

namespace ApiServer.Database.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DapperContext _context;

        public PlayerRepository(DapperContext context)
        {
            _context = context;
        }

        public bool Exist(string name)
        {
            var query = "SELECT COUNT(*) FROM player";
            using (var connection = _context.CreateConnection("game"))
            {
                var count = connection.ExecuteScalar<int>(query);
                return count > 0;
            }
        }
    }
}
