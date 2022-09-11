using Data.Interfaces;
using Data.Models.Server;
using LobbyServer.Networks;
using LobbyServer.Networks.Packets;
using System.Collections.Generic;
using System.Linq;

namespace LobbyServer.Services
{
    public class FeedbackService
    {
        public FeedbackService()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public async void SendServerList(Session session)
        {
            List<ServerModel> servers = await LobbyServer.ApiService.RequestServerList();

            new ResponseServerList(servers)
                .Send(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serverId"></param>
        /// <param name="channelId"></param>
        /// <param name="macAddress"></param>
        public async void SelectServerList(Session session, int serverId, int channelId, string macAddress)
        {
            ServerModel server = await LobbyServer
                .ApiService
                .RequestServer(serverId);

            ChannelModel channel = server
                .Channels
                .Where(ch => ch.Id == channelId)
                .FirstOrDefault();

            new ResponseSelectServer(server, channel)
                .Send(session); 
        }
    }
}
