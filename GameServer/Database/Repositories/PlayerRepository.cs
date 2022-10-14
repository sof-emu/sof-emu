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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public int SavePlayer(Player p)
        {
            try
            {
                int index = DB.Query("player").Where("account_id", p.AccountId).Get().Count();

                int id = DB.Query("player")
                    .InsertGetId<int>(new
                    {
                        account_id = p.AccountId,
                        name = p.Name,
                        index = index,
                        level = p.Level,
                        exp = 0,
                        online = 0,
                        job = p.Job,
                        job_level = p.JobLevel,
                        map_id = p.Position.MapId,
                        x = p.Position.X,
                        y = p.Position.Y,
                        z = p.Position.Z,
                        money = p.Inventory.Money,
                        faction = p.Faction,
                        hair_color = p.Appearance.HairColor,
                        hair_style = p.Appearance.HairStyle,
                        face = p.Appearance.Face,
                        voice = p.Appearance.Voice,
                        gender = p.Appearance.Gender,
                        title = p.Title
                    });

                p.PlayerId = id;
                p.Index = index;

                return id;
            }
            catch (Exception ex)
            {
                Log.ErrorException("SavePlayer: ", ex);
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool NameExists(string name)
        {
            bool exists = DB.Query("player")
                .Where("name", name)
                .Exists();

            return exists;
        }
    }
}
