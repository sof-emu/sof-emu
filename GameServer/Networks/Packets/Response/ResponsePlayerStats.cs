using Data.Structures.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponsePlayerStats : ASendPacket
    {
        private Player player;

        public ResponsePlayerStats(Player player)
        {
            this.player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            
        }
    }
}
