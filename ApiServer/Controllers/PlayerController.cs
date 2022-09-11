using ApiServer.Models.Contracts.Databases;
using Data.Models.Player;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Utility;

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
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [HttpGet("account_id/{accountId}")]
        public List<Player> GetByAccountId(int accountId)
        {
            return _playerRepository
                .GetPlayersByAccountId(accountId);
        }

        // GET api/<PlayerController>/5
        [HttpGet("{name}/exist")]
        public bool Exists(string name)
        {
            return _playerRepository.Exist(name);
        }

        // POST api/<PlayerController>
        [HttpPost]
        public Player Post([FromBody] Player player)
        {
            player = _playerRepository.SavePlayer(player);
            return player;
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
