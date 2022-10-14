namespace Data.Structures.Creature
{
    public class CreatureEffectsImpact
    {
        public int ChangeOfHp { get; set; }

        public int ChangeOfMp { get; set; }

        //Spirit
        public int ChangeOfSpirit { get; set; }

        //Strength
        public int ChangeOfStrength { get; set; }

        //Stamina
        public short ChangeOfStamina { get; set; }

        //Dexterity
        public short ChangeOfDexterity { get; set; }



        //Spirit
        public int ChangeOfAttack { get; set; }

        //Spirit
        public int ChangeOfDefense { get; set; }

        //Spirit
        public int ChangeOfAccuracy { get; set; }

        //Spirit
        public int ChangeOfDodge { get; set; }



        public int ChangeOfCriticalAttackRate { get; set; }

        public int ChangeOfComboAttackRate { get; set; }

        public int ChangeOfRageModeDuration { get; set; }

        public int ChangeOfReflectChance { get; set; }

        public int ChangeOfBlockDamageChance { get; set; }

        public int ChangeOfArmorBreakRate { get; set; }

        public int ChangeOfSkillCriticalRate { get; set; }

        public int ChangeOfAddAttackPowerRate { get; set; }

        public int ChangeOfDrainerRate { get; set; }

        public int ChangeOfSkillDodgeRate { get; set; }

        public int ChangeOfRageAttackDamagerRate { get; set; }

        public int ChangeOfRageIncreaseRate { get; set; }

        public void ResetChanges(Creature creature)
        {
            ChangeOfHp = 0;
            ChangeOfMp = 0;

            ChangeOfSpirit = 0;
            ChangeOfStrength = 0;
            ChangeOfStamina = 0;
            ChangeOfDexterity = 0;

            ChangeOfAttack = 0;
            ChangeOfDefense = 0;
            ChangeOfAccuracy = 0;
            ChangeOfDodge = 0;

            ChangeOfCriticalAttackRate = 0;
            ChangeOfSkillCriticalRate = 0;
            ChangeOfComboAttackRate = 0;
            ChangeOfRageModeDuration = 0;
            ChangeOfReflectChance = 0;
            ChangeOfBlockDamageChance = 0;
            ChangeOfArmorBreakRate = 0;
            ChangeOfAddAttackPowerRate = 0;
            ChangeOfDrainerRate = 0;
            ChangeOfSkillDodgeRate = 0;
            ChangeOfRageAttackDamagerRate = 0;
            ChangeOfRageIncreaseRate = 0;

            Player.Player player = creature as Player.Player;
            if (player != null)
            {

            }

            creature.Effects.ForEach(effect => effect.SetImpact(this));
        }

        public void ApplyChanges(CreatureBaseStats gameStats)
        {
            gameStats.HpBase += ChangeOfHp;
            gameStats.MpBase += ChangeOfMp;

            gameStats.Spirit += ChangeOfSpirit;
            gameStats.Strength += ChangeOfStrength;
            gameStats.Stamina += ChangeOfStamina;
            gameStats.Dexterity += ChangeOfDexterity;

            gameStats.Attack += ChangeOfAttack;
            gameStats.Defense += ChangeOfDefense;
            gameStats.Accuracy += ChangeOfAccuracy;
            gameStats.Dodge += ChangeOfDodge;

            gameStats.CriticalAttackRate += ChangeOfCriticalAttackRate;
            gameStats.SkillCriticalRate += ChangeOfSkillCriticalRate;
            gameStats.ComboAttackRate += ChangeOfComboAttackRate;
            gameStats.RageModeDuration += ChangeOfRageModeDuration;
            gameStats.ReflectChance += ChangeOfReflectChance;
            gameStats.BlockDamageChance += ChangeOfBlockDamageChance;
            gameStats.ArmorBreakRate += ChangeOfArmorBreakRate;
            gameStats.AddAttackPowerRate += ChangeOfAddAttackPowerRate;
            gameStats.DrainerRate += ChangeOfDrainerRate;
            gameStats.SkillDodgeRate += ChangeOfSkillDodgeRate;
            gameStats.RageAttackDamagerRate += ChangeOfRageAttackDamagerRate;
            gameStats.RageIncreaseRate += ChangeOfRageIncreaseRate;
        }
    }
}
