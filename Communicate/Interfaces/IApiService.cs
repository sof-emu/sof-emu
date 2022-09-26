﻿using Data.Models.Account;
using Data.Models.Creature;
using Data.Models.Player;
using Data.Models.Server;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Communicate.Interfaces
{
    public interface IApiService : IComponent
    {
        Task<bool> CheckNameExist(string name);
        Task<List<Player>> GetPlayerFromAccountId(int id);
        Task<BaseStats> GetPlayerStats(int playerId);
        Task<AccountData> RequestAccountData(string username);
        Task<Player> SendCreatePlayer(Player player);
        Task<bool> SendDeletePlayer(int index, string password);
        void SendServerInfo(ServerModel model);
    }
}
