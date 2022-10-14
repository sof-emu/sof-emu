using Data.Enums;
using Data.Enums.Item;
using Data.Interfaces;
using Data.Structures.World;
using System.Collections.Generic;

namespace Data.Structures.Player
{
    public class Player : Creature.Creature
    {
        public Creature.Creature ObservedCreature = null;

        public IVisible Visible;
        public ISession Session;
        public IController Controller;

        public Appearance Appearance;
        public Storage Inventory = new Storage { StorageType = StorageType.Inventory };
        public List<int> Skills = new List<int>();
        public PlayerMode PlayerMode = PlayerMode.Normal;

        public int PlayerId;
        public int AccountId;
        public string Name;
        public int Index;
        public int Level = 1;
        public PlayerClass Job;
        public int JobLevel = 1;
        public long Exp = 0;
        public int Title = 0;
        public int Faction;
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

        public override int GetModelId()
        {
            return 0;
        }
    }
}
