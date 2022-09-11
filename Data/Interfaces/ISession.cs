using Data.Models.Account;
using Data.Models.Player;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ISession
    {
        void SendPacket(byte[] data);
        short SessionId { get; }
        AccountData GetAccount();
        void SetAccount(AccountData account);
        List<Player> GetPlayers();
        Player GetPlayer(int id);
        void AddPlayer(Player player);
        void SetSelectPlayer(Player player);
        Player GetSelectedPlayer();
    }
}
