using Data.Models.Template.Item;

namespace Data.Models.Player
{
    public class InventoryItem
    {
        private ItemTemplate template;

        public InventoryItem(ItemTemplate template)
        {
            this.template = template;
        }

        public InventoryItem(int itemId)
        {
            template = Data.ItemTemplates[itemId];
        }

        public int ItemId
        {
            get { return template.Id; }
        }
    }
}
