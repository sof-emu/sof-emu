using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseStatusEffect : ASendPacket
    {
        protected int WgId;
        protected int SwitchInt;
        protected int Sj;

        public ResponseStatusEffect(int wgId, int switchInt, int sj)
        {
            WgId = wgId;
            SwitchInt = switchInt;
            Sj = sj;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteQ(writer, WgId);
            WriteD(writer, 0);
            WriteD(writer, SwitchInt);
            WriteD(writer, Sj);
            WriteD(writer, 0);
        }
    }
}
