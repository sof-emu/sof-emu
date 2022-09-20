using Data.Enums;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseInventoryInfo : ASendPacket
    {
        protected InventoryType inventoryType;

        public ResponseInventoryInfo(InventoryType type)
        {
            inventoryType = type;
        }

        public override void Write(BinaryWriter writer)
        {
            switch(inventoryType)
            {
                case InventoryType.Equipment:
                    {
                        WriteC(writer, 1);
                        WriteC(writer, 2);
                        WriteC(writer, 0);
                        WriteH(writer, 0);
                        for (int i = 0; i < 96; i++)
                        {
                            WriteB(writer, new byte[96]);
                        }
                    }
                    break;
                case InventoryType.ConcentratingBead:
                    {
                        WriteC(writer, 171);
                        for (int i = 0; i < 6; i++)
                        {
                            WriteB(writer, new byte[96]);
                        }
                    }
                    break;
            }
        }
    }
}
