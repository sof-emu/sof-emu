using Data.Interfaces;

namespace Communicate.Interfaces
{
    public interface IAuthService : IComponent
    {
        void Authenticate(ISession session, string username, string ipAddress, string macAddress);
    }
}
