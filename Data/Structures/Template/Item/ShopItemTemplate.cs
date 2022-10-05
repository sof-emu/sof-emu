using Newtonsoft.Json;
using System.Linq;

namespace Data.Structures.Template.Item
{
    public class ShopItemTemplate
    {
        public int ItemId { get; set; }
        public int Cost { get; set; }
        public int Skill_1 { get; set; }
        public int Skill_2 { get; set; }
        public int Skill_3 { get; set; }
        public int Skill_4 { get; set; }
        public int Skill_5 { get; set; }
        public int RequireSkill { get; set; }

        [JsonIgnore]
        public int SkillCount
        {
            get
            {
                int count = 0;
                foreach (var propInfo in this.GetType().GetProperties().Where(p => p.Name.StartsWith("Skill_")).ToList())
                    if (((int)this.GetType().GetProperty(propInfo.Name).GetValue(this)) > 0)
                        count++;

                return count;
            }
        }
    }
}
