using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseNotifyPlayer : ASendPacket
    {
        protected int Unk1;
        protected int Unk2;

        public ResponseNotifyPlayer(int unk1, int unk2)
        {
            Unk1 = unk1;
            Unk2 = unk2;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteC(writer, (byte)Unk1);
            if(Unk1 == 3)
                WriteD(writer, Unk2);
        }
    }
}
