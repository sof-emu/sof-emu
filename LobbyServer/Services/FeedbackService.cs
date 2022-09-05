using Data.Interfaces;
using LobbyServer.Networks;
using LobbyServer.Networks.Packets;

namespace LobbyServer.Services
{
    public class FeedbackService : IService
    {
        protected Session session;

        public FeedbackService(Session sess)
        {
            session = sess;
        }

        public void SendServerList()
        {
            // todo request available server and channel from game server

            new ResponseServerList()
                .Send(session);
        }
    }
}
