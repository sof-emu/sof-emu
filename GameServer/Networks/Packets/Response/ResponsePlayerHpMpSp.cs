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

            WriteD(writer, Player.GetGameStats().Hp);
            WriteD(writer, Player.GetGameStats().Mp);
            WriteD(writer, Player.GetGameStats().Sp);

            WriteD(writer, Player.GetGameStats().HpBase);
            WriteD(writer, Player.GetGameStats().MpBase);
            WriteD(writer, Player.GetGameStats().SpBase);

            WriteD(writer, 0);
        }
    }
}
