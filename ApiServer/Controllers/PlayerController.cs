using ApiServer.Models.Contracts.Databases;
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

        // GET api/<PlayerController>/5
        [HttpGet("{name}/exist")]
        public bool Exists(string name)
        {
            return _playerRepository.Exist(name);
        }

        // POST api/<PlayerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
