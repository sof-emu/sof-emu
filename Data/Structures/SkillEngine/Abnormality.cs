using Data.Enums.SkillEngine;
using System.Collections.Generic;

namespace Data.Structures.SkillEngine
{
    public class Abnormality
    {
        public int Id { get; set; }
        public bool Infinity { get; set; }
        public bool IsBuff { get; set; }
        public int Level { get; set; }
        public bool NotCareDeath { get; set; }
        public int Priority { get; set; }
        public int Property { get; set; }
        public int Time { get; set; }
        public AbnormalityShowType IsShow { get; set; }
        public bool IsHideOnRefresh { get; set; }
        public List<AbnormalityEffect> Effects { get; set; }
        public string Name { get; set; }

        public Abnormality()
        {
            Effects = new List<AbnormalityEffect>();
        }
    }
}
