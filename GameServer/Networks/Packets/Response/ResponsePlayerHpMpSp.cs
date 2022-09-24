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

            WriteD(writer, Player.GetStats().Hp);
            WriteD(writer, Player.GetStats().Mp);
            WriteD(writer, Player.GetStats().Sp);

            WriteD(writer, Player.GetStats().HpBase);
            WriteD(writer, Player.GetStats().MpBase);
            WriteD(writer, Player.GetStats().SpBase);

            WriteD(writer, 0);
        }
    }
}
