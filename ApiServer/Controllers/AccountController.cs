using ApiServer.Models.Contracts.Databases;
using ApiServer.Models.Account;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountDataRepository _accountRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountRepository"></param>
        public AccountController(IAccountDataRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("count")]
        public int Count()
        {
            try
            {
                return _accountRepository.GetCount();
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// GET api/<AccountController>/username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("{username}")]
        public async Task<AccountData> GetByUsername(string username)
        {
            try
            {
                return await _accountRepository.GetAccount(username);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// POST api/<AccountController>
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // todo create account
        }

        /// <summary>
        /// PUT api/<AccountController>/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // todo update account
        }
    }
}
