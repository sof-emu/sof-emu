using Data.Models.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponsePlayerHpMpSp : ASendPacket
    {
        protected Player Player;

        public ResponsePlayerHpMpSp(Player player)
        {
            Player = player;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 0);

            WriteD(writer, 555);
            WriteD(writer, 554);
            WriteD(writer, 553);

            WriteD(writer, 999);
            WriteD(writer, 998);
            WriteD(writer, 997);

            WriteD(writer, 0);
        }
    }
}
