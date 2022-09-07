using ApiServer.Models;
using ApiServer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiServer.Controllers
{
    [Route("api/server")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly ContainerService _container;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountRepository"></param>
        public ServerController(ContainerService container)
        {
            _container = container;
        }

        /// <summary>
        /// GET: api/<ServerController>
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Server> Get()
        {
            var servers = _container.GetServers();
            return servers;
        }

        /// <summary>
        /// GET api/<ServerController>/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Server Get(int id)
        {
            return _container.GetServer(id);
        }

        /// <summary>
        /// POST api/<ServerController>
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Server server)
        {
            //Console.WriteLine(server.Id);
            _container.AddServer(server);
            return Ok("Success");
        }

        /// <summary>
        /// PUT api/<ServerController>/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // todo update server data
        }

        /// <summary>
        /// DELETE api/<ServerController>/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // todo delete server data from list
            // occure when try to close game server, game server send api before ended App
        }
    }
}
