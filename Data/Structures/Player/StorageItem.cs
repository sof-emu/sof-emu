using Data.Enums.Item;
using Data.Structures.Template.Item;

namespace Data.Structures.Player
{
    public class StorageItem : RxjhObject
    {
        public int ItemId = 0;

        public int Magic0 = 0;
        public int Magic1 = 0;
        public int Magic2 = 0;
        public int Magic3 = 0;
        public int Magic4 = 0;

        public int BonusMagic1 = 0;
        public int BonusMagic2 = 0;
        public int BonusMagic3 = 0;
        public int BonusMagic4 = 0;
        public int BonusMagic5 = 0;

        public int LimitTime = 0;
        public int Upgrade = 0;
        public int Quality = 0;
        public int Lock = 0;

        private int _amount = 1;

        public ItemState State = ItemState.UPDATE;

        public int Amount
        {
            get //Hack prevent
            {
                if (_amount > 99 && ItemId != 2000000000) _amount = 99;
                if (_amount < 0) _amount = 0;
                return _amount;
            }
            set { _amount = value; }
        }

        public ItemTemplate ItemTemplate
        {
            get { return ItemTemplate.Factory(ItemId); }
        }
    }
}
