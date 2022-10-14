using Data.Enums;
using Data.Structures.Player;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseInventoryInfo : ASendPacket
    {
        protected InventoryType inventoryType;
        private Storage inventory;

        public ResponseInventoryInfo(InventoryType type)
        {
            inventoryType = type;
        }

        public ResponseInventoryInfo(Storage inventory)
        {
            this.inventory = inventory;
        }

        public override void Write(BinaryWriter writer)
        {
            switch(inventoryType)
            {
                case InventoryType.Item:
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
                case InventoryType.Orb:
                    {
                        WriteC(writer, 171);
                        for (int i = 0; i < 6; i++)
                        {
                            WriteB(writer, new byte[96]);
                        }
                    }
                    break;
                case InventoryType.Pet: // When summon pet
                    {
                        WriteD(writer, 60);
                        WriteD(writer, 0);
                        for (int i = 0; i < 16; i++)
                        {
                            WriteB(writer, new byte[96]);
                        }
                    }
                    break;
            }
        }
    }
}
