using ApiServer.Models;
using ApiServer.Models.Contracts;

namespace ApiServer.Services
{
    public class ContainerService
    {
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<int, Server> Servers;

        /// <summary>
        /// 
        /// </summary>
        public ContainerService()
        {
            Servers = new Dictionary<int, Server>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        public void AddServer(Server server)
        {
            Servers.Add(server.Id, server);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Server GetServer(int id)
        {
            return Servers[id];
        }

        //
        public List<Server> GetServers()
        {
            return Servers
                .Values
                .ToList();
        }
    }
}
