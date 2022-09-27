using ApiServer.Models.Contracts.Databases;
using Data.Models.Creature;
using Data.Models.Player;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountRepository"></param>
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        /// <summary>
        /// GET api/player/account_id/{accountId}
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("account_id/{accountId}")]
        public List<Player> GetByAccountId(int accountId)
        {
            var result = _playerRepository
                .GetPlayersByAccountId(accountId);
            return result;
        }

        /// <summary>
        /// GET api/player/5
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}/exist")]
        public bool Exists(string name)
        {
            return _playerRepository.Exist(name);
        }

        /// <summary>
        /// GET api/player/{playerId}/stats
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [HttpGet("{playerId}/stats")]
        public GameStats GetStatsById(int playerId)
        {
            return _playerRepository.GetPlayerStats(playerId);
        }

        // POST api/player
        [HttpPost]
        public Player Post([FromBody] Player player)
        {
            player = _playerRepository.SavePlayer(player);
            return player;
        }

        /// <summary>
        /// POST api/player/{playerId}/stats
        /// </summary>
        /// <param name="stats"></param>
        [HttpPost("{playerId}/stats")]
        public void PostStats([FromBody] GameStats stats, int playerId)
        {
            _playerRepository.SavePlayerStats(playerId, stats);
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpDelete("{playerId}/{delete_key}")]
        public bool DeletePlayer(int id, string password)
        {
            return _playerRepository.DeletePlayer(id, password);
        }
    }
}
