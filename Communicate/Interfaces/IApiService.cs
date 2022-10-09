using Data.Structures.Template.Server;

namespace Communicate.Interfaces
{
    public interface IApiService : IComponent
    {
        void SendServerInfo(ServerModel model);
    }
}
