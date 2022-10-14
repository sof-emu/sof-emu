namespace Data.Structures.SkillEngine
{
    public class AbnormalityEffect
    {
        public int AppearEffectId { get; set; }
        public int AttackEffectId { get; set; }
        public int DamageEffectId { get; set; }
        public int DisappearEffectId { get; set; }
        public int EffectId { get; set; }
        public string EffectPart { get; set; }
        public int TickInterval { get; set; }
        public float Value { get; set; }
        public AbnormalityEffect()
        {
            EffectPart = "";
        }
    }
}
