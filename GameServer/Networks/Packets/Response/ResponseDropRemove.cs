using Data.Structures.World;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseDropRemove : ASendPacket
    {
        protected Item Item;

        public ResponseDropRemove(Item item)
        {
            Item = item;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteQ(writer, Item.UID);
        }
    }
}
