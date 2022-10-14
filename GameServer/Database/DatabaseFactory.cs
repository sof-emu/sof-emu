using Communicate;
using GameServer.Database.Repositories;
using SqlKata.Execution;

namespace GameServer.Database
{
    public class DatabaseFactory
    {
        private QueryFactory accountContext;
        private QueryFactory gameContext;

        public DatabaseFactory()
        {
            accountContext = new DapperContext().GetQueryFactory("db_account");
            gameContext = new DapperContext().GetQueryFactory("db_game");

            Global.AccountRepository = new AccountRepository(accountContext);
            Global.PlayerRepository = new PlayerRepository(gameContext);
            Global.InventoryRepository = new InventoryRepository(gameContext);
        }
    }
}
