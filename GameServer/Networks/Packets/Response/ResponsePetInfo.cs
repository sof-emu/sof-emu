using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponsePetInfo : ASendPacket
    {
        public ResponsePetInfo()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 11);
            WriteD(writer, 1);
            WriteSN(writer, string.Empty); // Pet name

            WriteC(writer, 0);
            WriteD(writer, 0);

            WriteC(writer, 0); // Pet Job
            WriteC(writer, 0); // Pet Job Level

            WriteH(writer, 0); // Pet Level

            WriteD(writer, 0); // Magic 1
            WriteD(writer, 0); // Magic 2
            WriteD(writer, 0); // Magic 3
            WriteD(writer, 0); // Magic 4
            WriteD(writer, 0); // Magic 5

            WriteQ(writer, 0); // Pet Exp current
            WriteQ(writer, 0); // Pet Exp to levelup
            WriteQ(writer, 0); // Equipment item slot 14 item id
        }
    }
}
