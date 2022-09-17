using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseInventoryInfo : ASendPacket
    {
        public ResponseInventoryInfo()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, 1);
            WriteD(writer, 0);

            for (int i = 0; i < 66; i++)
            {
                //if (Storage.Items.ContainsKey(i))
                //    WriteItemInfo(writer, Storage.GetItem(i));
                //else
                    WriteB(writer, new byte[88]);
            }
        }
    }
}
