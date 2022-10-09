using Data.Interfaces.Database;
using SqlKata.Execution;

namespace GameServer.Database.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private QueryFactory DB;

        public InventoryRepository(QueryFactory db)
        {
            DB = db;
        }
    }
}
