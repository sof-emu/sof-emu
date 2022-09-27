using System.Collections.Generic;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    /// <summary>
    /// 0x0091
    /// </summary>
    public class ResponseNpcInteraction : ASendPacket
    {
        protected int ShopId;
        protected int ActionId;
        protected int TabIndex;
        private List<object> Items;

        public ResponseNpcInteraction(int shopId, int actionId)
        {
            ShopId = shopId;
            ActionId = actionId;
        }

        public ResponseNpcInteraction(int shopId, int actionId, int tabIndex) : this(shopId, actionId)
        {
        }

        public ResponseNpcInteraction(int shopId, int actionId, int tab, List<object> items) : this(shopId, actionId)
        {
            ShopId = shopId;
            ActionId = actionId;
            TabIndex = tab;
            Items = items;
        }

        public override void Write(BinaryWriter writer)
        {
            // 01000000 01000000 01000000 00000000 00000000 00000000
            WriteD(writer, ActionId); // Action Id
            WriteD(writer, ActionId); // Action Id
            WriteD(writer, ShopId); // Shop Id

            if(Items != null)
            {
                WriteD(writer, Items.Count);
                WriteD(writer, 0);
                if (TabIndex == 0)
                {
                    int num = Items.Count / 60;
                    if (Items.Count % 60 > 0)
                        num++;

                    WriteQ(writer, num);
                }
                else
                    WriteQ(writer, TabIndex);

                foreach (object item in Items)
                {
                    WriteQ(writer, 0 /*item.Id*/);
                    WriteQ(writer, 0);
                    WriteQ(writer, -1);
                }
            }
            else
            {
                WriteD(writer, 0);
                WriteD(writer, 0);
                WriteD(writer, 0);
            }
        }
    }
}
