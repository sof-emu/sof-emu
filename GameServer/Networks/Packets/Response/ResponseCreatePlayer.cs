using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseCreatePlayer : ASendPacket
    {
        protected bool IsSuccess;

        public ResponseCreatePlayer(bool success)
        {
            IsSuccess = success;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, (IsSuccess == true) ? 1 : 0);
        }
    }
}
