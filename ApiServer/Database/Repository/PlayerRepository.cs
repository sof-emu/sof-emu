using ApiServer.Models.Contracts.Databases;
using Data.Models.Player;
using Data.Models.World;
using SqlKata.Execution;

namespace ApiServer.Database.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DapperContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public PlayerRepository(DapperContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Exist(string name)
        {
            using (var db = _context.GetQueryFactory("game"))
            {
                bool isExist = db.Query("player")
                    .Where("name", name)
                    .Exists();

                return isExist;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<Player> GetPlayersByAccountId(int accountId)
        {
            using(var db = _context.GetQueryFactory("game"))
            {
                var list = db.Query("player")
                    .Where("account_id", accountId)
                    .Get()
                    .ToList();

                List<Player> result = new List<Player>();
                foreach(var data in list)
                {
                    Player p = new Player();
                    p.Id = data.id;
                    p.AccountId = data.account_id;
                    p.Name = data.name;
                    p.Index = data.index;
                    p.Level = data.level;
                    p.Exp = data.exp;
                    p.Online = data.online;
                    p.Job = data.job;
                    p.JobLevel = data.job_level;
                    p.Money = data.money;
                    p.Force = data.force;
                    p.HairColor = data.hair_color;
                    p.Face = data.face;
                    p.Voice = data.voice;
                    p.Gender = data.gender;
                    p.Title = data.title;
                    
                    Position pos = new Position();
                    pos.MapId = data.map_id;
                    pos.X = data.x;
                    pos.Y = data.y;
                    pos.Z = data.z;

                    p.Position = pos;

                    result.Add(p);
                }

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Player SavePlayer(Player p)
        {
            using (var db = _context.GetQueryFactory("game"))
            {
                var index = db.Query("player")
                    .Where("account_id", p.AccountId)
                    .Get()
                    .Count();

                int id = db.Query("player")
                    .InsertGetId<int>(new
                    {
                        account_id = p.AccountId,
                        account_name = p.AccountName,
                        name = p.Name,
                        index = index,
                        level = p.Level,
                        exp = p.Exp,
                        online = 0,
                        job = p.Job,
                        job_level = p.JobLevel,
                        x = p.Position.X,
                        y = p.Position.Y,
                        z = p.Position.Z,
                        money = p.Money,
                        force = p.Force,
                        hair_color = p.HairColor,
                        face = p.Face,
                        voice = p.Voice,
                        gender = p.Gender,
                        title = p.Title
                    });

                p.Id = id;

                return p;
            }
        }
    }
}
