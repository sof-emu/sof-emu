using Hik.Communication.Scs.Communication.Messages;

namespace GameServer.Networks.Messages
{
    public class GameMessage : ScsMessage
    {
        public short PackSize;
        public short Hash;
        public short OpCode;
        public byte[] Data;
    }
}
