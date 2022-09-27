using Data.Models.Creature;
using Data.Models.Player;

namespace ApiServer.Models.Contracts.Databases
{
    public interface IPlayerRepository
    {
        public bool Exist(string name);
        List<Player> GetPlayersByAccountId(int accountId);
        GameStats GetPlayerStats(int playerId);
        public Player SavePlayer(Player player);
        void SavePlayerStats(int playerId, GameStats stats);
    }
}
