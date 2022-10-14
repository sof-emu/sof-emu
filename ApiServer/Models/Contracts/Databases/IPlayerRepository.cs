using Data.Structures.Creature;
using Data.Structures.Player;

namespace ApiServer.Models.Contracts.Databases
{
    public interface IPlayerRepository
    {
        bool DeletePlayer(int id, string password);
        public bool Exist(string name);
        List<Player> GetPlayersByAccountId(int accountId);
        CreatureBaseStats GetPlayerStats(int playerId);
        public Player SavePlayer(Player player);
        void SavePlayerStats(int playerId, CreatureBaseStats stats);
    }
}
