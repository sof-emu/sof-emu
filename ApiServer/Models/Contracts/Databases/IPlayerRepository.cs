using Data.Models.Player;

namespace ApiServer.Models.Contracts.Databases
{
    public interface IPlayerRepository
    {
        public bool Exist(string name);
        List<Player> GetPlayersByAccountId(int accountId);
        public Player SavePlayer(Player player);
    }
}
