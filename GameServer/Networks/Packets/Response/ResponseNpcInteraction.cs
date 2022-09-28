using Data.Models.Template.Item;
using System.Collections.Generic;
using System.IO;
using Utility;

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
        private List<ShopItemTemplate> Items;

        public ResponseNpcInteraction(int shopId, int actionId)
        {
            ShopId = shopId;
            ActionId = actionId;
        }

        public ResponseNpcInteraction(int shopId, int actionId, int tabIndex) : this(shopId, actionId)
        {
            TabIndex = tabIndex;
        }

        public ResponseNpcInteraction(int shopId, int actionId, int tab, List<ShopItemTemplate> items) : this(shopId, actionId, tab)
        {
            Items = items;
        }

        public override void Write(BinaryWriter writer)
        {
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

                foreach (ShopItemTemplate item in Items)
                {
                    Log.Debug($"SkillCount: {item.SkillCount}");
                    WriteQ(writer, item.ItemId);

                    if (item.SkillCount > 0)
                    {
                        WriteQ(writer, item.SkillCount);
                        if (item.Skill_1 > 0)
                            WriteQ(writer, item.Skill_1);
                        if (item.Skill_2 > 0)
                            WriteQ(writer, item.Skill_2);
                        if (item.Skill_3 > 0)
                            WriteQ(writer, item.Skill_3);
                        if (item.Skill_4 > 0)
                            WriteQ(writer, item.Skill_4);
                    }
                    else
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
