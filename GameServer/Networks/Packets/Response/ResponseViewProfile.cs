using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseViewProfile : ASendPacket
    {
        public ResponseViewProfile()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, 0);
            WriteH(writer, 0); // Count

            /*foreach(var profile in Profiles)
            {
                WriteD(writer, profile.Id);
                WriteC(writer, profile.IsNpc ? 0 : 1);
                WriteSN(writer, profile.Name);
                WriteB(writer, new byte[5]);
                WriteC(writer, 22); // year - 2000
                WriteC(writer, 9); // month
                WriteC(writer, 21); //day
                WriteC(writer, 23); // hour
                WriteC(writer, 49); // minute
                WriteH(writer, 0); // Reading ?
            }*/
        }
    }
}
