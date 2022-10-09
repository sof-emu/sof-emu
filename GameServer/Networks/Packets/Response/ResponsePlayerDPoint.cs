using Data.Structures.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponsePlayerDPoint : ASendPacket
    {
        private Player player;

        public ResponsePlayerDPoint(Player player)
        {
            this.player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteQ(writer, 0);
        }
    }
}
