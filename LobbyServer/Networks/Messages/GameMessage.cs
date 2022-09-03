using Hik.Communication.Scs.Communication.Messages;

namespace LobbyServer.Networks.Messages
{
    public class GameMessage : ScsMessage
    {
        public short OpCode;

        public byte[] Data;
    }
}
