using Hik.Communication.Scs.Communication.Messages;

namespace GameServer.Networks.Messages
{
    public class GameMessage : ScsMessage
    {
        public short OpCode;
        public byte[] Data;
    }
}
