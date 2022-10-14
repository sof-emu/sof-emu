using Data.Structures.Account;
using Data.Structures.Player;

namespace Data.Interfaces
{
    public interface ISession
    {
        Account Account { get; set; }
        Player Player { get; set; }
        bool IsValid { get; }

        void Close();
        void SendPacket(byte[] data);
        long Ping();
    }
}
