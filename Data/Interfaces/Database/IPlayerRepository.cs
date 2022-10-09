using Data.Structures.Player;
using System.Collections.Generic;

namespace Data.Interfaces.Database
{
    public interface IPlayerRepository
    {
        List<Player> GetPlayerFromAccountId(int accountId);
    }
}
