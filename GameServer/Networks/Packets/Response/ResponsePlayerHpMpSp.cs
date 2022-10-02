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

            WriteD(writer, Player.GetLifeStats().Hp);
            WriteD(writer, Player.GetLifeStats().Mp);
            WriteD(writer, Player.GetLifeStats().Sp);

            WriteD(writer, Player.GetLifeStats().MaxHp);
            WriteD(writer, Player.GetLifeStats().MaxMp);
            WriteD(writer, Player.GetLifeStats().MaxSp);

            WriteD(writer, 0);
        }
    }
}
