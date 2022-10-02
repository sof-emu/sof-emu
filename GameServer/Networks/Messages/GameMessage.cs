using Hik.Communication.Scs.Communication.Messages;

namespace GameServer.Networks.Messages
{
    public class GameMessage : ScsMessage
    {
        public int ObjectId;
        public short Opcode;
        public byte[] Data;
    }
}
