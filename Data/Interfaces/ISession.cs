using Data.Structures.Account;
using Data.Structures.Player;
using System;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ISession
    {
        void SendPacket(byte[] data);
        short SessionId { get; }
        Account GetAccount();
        void SetAccount(Account account);
        List<Player> GetPlayers();
        Player GetPlayer(int index);
        void AddPlayer(Player player);
        void SetSelectPlayer(Player player);
        Player GetSelectedPlayer();
        void SetSetting(SettingOption setting);
        SettingOption GetSetting();
        void SetLastPing(DateTime last);
        DateTime GetLastPing();
        void SetPlayer(List<Player> players);
    }
}
