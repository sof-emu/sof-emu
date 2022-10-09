using Data.Enums;
using Data.Interfaces.Database;
using Data.Structures.Player;
using Data.Structures.World;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace GameServer.Database.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private QueryFactory DB;

        public PlayerRepository(QueryFactory db)
        {
            DB = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<Player> GetPlayerFromAccountId(int accountId)
        {
            try
            {
                var list = DB.Query("player")
                    .Where("account_id", accountId)
                    .Get()
                    .ToList();

                List<Player> Players = new List<Player>();

                list.ForEach(_player =>
                { 
                    Log.Debug($"_player = {_player}");

                    Player p = new Player()
                    {
                        AccountId = _player.account_id,
                        Name = _player.name,
                        Index = _player.index,
                        Level = _player.level,
                        Exp = _player.exp,
                        Job = Enum.Parse(typeof(PlayerClass), _player.job),
                        JobLevel = _player.job_level,
                        Position = new WorldPosition()
                        {
                            MapId = _player.map_id,
                            X = _player.x,
                            Y = _player.y,
                            Z = _player.z,
                        },
                        Faction = _player.faction,
                        Appearance = new Appearance()
                        {
                            HairColor = _player.hair_color,
                            HairStyle = _player.hair_style,
                            Face = _player.face,
                            Voice = _player.voice,
                            Gender = _player.gender,
                        },
                        Title = _player.title,
                    };

                    p.Inventory.Money = _player.money;

                    Players.Add(p);
                });

                return Players;
            }
            catch (Exception ex)
            {
                Log.ErrorException("GetPlayerFromAccountId: ", ex);
                return new List<Player>();
            }
        }
    }
}
