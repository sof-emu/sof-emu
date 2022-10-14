using Data.Enums;
using Data.Structures.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseChatMessage : ASendPacket
    {
        protected Player Player;
        protected string Message;
        protected ChatType Type;

        private bool systemMessage = false;

        public ResponseChatMessage(Player player, string message, ChatType type)
        {
            Player = player;
            Message = message;
            Type = type;

            if (Type == ChatType.Announce || Type == ChatType.UNK1 || Type == ChatType.UNK2)
                systemMessage = true;
        }

        public ResponseChatMessage(string message, ChatType type)
        {
            Message = message;
            Type = type;

            if (Type == ChatType.Announce || Type == ChatType.UNK1 || Type == ChatType.UNK2)
                systemMessage = true;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, (byte)Type);

            if (systemMessage)
                WriteSN(writer, "System");
            else
                WriteSN(writer, Player.Name);

            WriteB(writer, new byte[7]);
            WriteS(writer, Message);

            writer.Seek(2, SeekOrigin.Begin);
            WriteH(writer, (int)((systemMessage) ? 0 : Player.UID));
            writer.Seek(0, SeekOrigin.End);
        }
    }
}
