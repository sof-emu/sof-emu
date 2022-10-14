using Data.Enums;

namespace Data.Structures.Creature
{
    public class CreatureBaseStats
    {
        public PlayerClass PlayerClass { get; set; }
        public int Level { get; set; }
        public long Exp { get; set; }

        //HpMpSp
        public int HpBase { get; set; }
        public int MpBase { get; set; }
        public int SpBase { get; set; }

        //Combat
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Accuracy { get; set; }
        public int Dodge { get; set; }
        public int SkillAttack { get; set; }
        public int SkillDefense { get; set; }

        //Stats
        public int Spirit { get; set; }
        public int Strength { get; set; }
        public int Stamina { get; set; }
        public int Dexterity { get; set; }

        //Regen
        public int NaturalMpRegen { get; set; }

        // Additional stats
        public int CriticalAttackRate = 0;
        public int SkillCriticalRate = 0;
        public int ComboAttackRate = 0;
        public int RageModeDuration = 15;
        public int ReflectChance = 0;
        public int BlockDamageChance = 0;
        public int ArmorBreakRate = 0;
        public int AddAttackPowerRate = 0;
        public int DrainerRate = 0;
        public int SkillDodgeRate = 0;
        public int RageAttackDamagerRate = 0;
        public int RageIncreaseRate = 0;

        public CreatureBaseStats Clone()
        {
            return (CreatureBaseStats)MemberwiseClone();
        }

        public void CopyTo(CreatureBaseStats gameStats)
        {
            //HpMp
            gameStats.HpBase = HpBase;
            gameStats.MpBase = MpBase;
            gameStats.SpBase = SpBase;

            //Combat
            gameStats.Attack = Attack;
            gameStats.Defense = Defense;
            gameStats.Accuracy = Accuracy;
            gameStats.Dodge = Dodge;

            //Stats
            gameStats.Spirit = Spirit;
            gameStats.Strength = Strength;
            gameStats.Stamina = Stamina;
            gameStats.Dexterity = Dexterity;

            //Regen
            gameStats.NaturalMpRegen = NaturalMpRegen;
        }
    }
}