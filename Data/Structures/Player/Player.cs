using Data.Interfaces;
using Data.Structures.World;

namespace Data.Structures.Player
{
    public class Player : Creature.Creature
    {
        public Creature.Creature ObservedCreature = null;

        public IVisible Visible;
        public ISession Session;
        public IController Controller;

        public int PlayerId;
        public int ServerId { get; set; }
        public int Level = 1;
        public int JobLevel = 1;
        public long Exp = 0;
        public int SkillPoint = 0;
        public int AbilityPoint = 0;
        public int AscensionPoint = 0;
        public int CurrentAscensionPoint = 0;
        public int HonorPoint = 0;
        public int KarmaPoint = 0;
        public int DPoint = 0;
        public int CraftType = 0;
        public int CraftLevel = 0;
        public int CraftExp = 0;
        public bool IsRage = false;

        public Player()
        {
            Position = new WorldPosition();
        }

        public override int GetLevel()
        {
            return Level;
        }
    }
}
