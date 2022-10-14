namespace Data.Structures.Template.Item
{
    public class ItemTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Side1 { get; set; }
        public int Side2 { get; set; }
        public int Job { get; set; }
        public int Level { get; set; }
        public int JobLevel { get; set; }
        public int Gender { get; set; }
        //public int Category { get; set; }
        //public int SubCategory { get; set; }
        public int Weight { get; set; }
        public int MinAttack { get; set; }
        public int MaxAttack { get; set; }
        public int Defense { get; set; }
        public int Accuracy { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Zx { get; set; }
        /// <summary>
        /// NJ
        /// </summary>
        public int Unk1 { get; set; }
        /// <summary>
        /// EL
        /// </summary>
        public int Unk2 { get; set; }
        /// <summary>
        /// MM1
        /// </summary>
        public int SalePrice { get; set; }
        public int Wx { get; set; }
        public int Wxjd { get; set; }

        private static readonly ItemTemplate NullTemplate = new ItemTemplate();

        public static ItemTemplate Factory(int id)
        {
            return !Data.ItemTemplates.ContainsKey(id) ? NullTemplate : Data.ItemTemplates[id];
        }
    }
}
