using Data.Structures.Player;
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

            WriteD(writer, Player.LifeStats.Hp);
            WriteD(writer, Player.LifeStats.Mp);
            WriteD(writer, Player.LifeStats.Sp);

            WriteD(writer, Player.GameStats.HpBase);
            WriteD(writer, Player.GameStats.MpBase);
            WriteD(writer, Player.GameStats.SpBase);

            WriteD(writer, 0);
        }
    }
}
