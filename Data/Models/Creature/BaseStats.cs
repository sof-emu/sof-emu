using System.Runtime.InteropServices;

namespace Data.Models.Creature
{
    public class BaseStats
    {
        private int _accuracy;
        private int _attack;
        private int _defense;
        private int _dodge;
        private long _exp;
        private int _level;
        private int _job;
        private int _hpBase;
        private int _mpBase;
        private int _spBase;
        private int _naturalMpRegen;
        private int _skillAttack;
        private int _skillDefense;
        private int _dexterity;
        private int _spirit;
        private int _stamina;
        private int _strength;

        private int _hp;
        private int _mp;
        private int _sp;

        public int Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; }
        }
        public int Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }
        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }
        public int Dodge
        {
            get { return _dodge; }
            set { _dodge = value; }
        }
        public long Exp
        {
            get { return _exp; }
            set { _exp = value; }
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        public int Job
        {
            get { return _job; }
            set { _job = value; }
        }
        public int HpBase
        {
            get { return _hpBase; }
            set { _hpBase = value; }
        }
        public int MpBase
        {
            get { return _mpBase; }
            set { _mpBase = value; }
        }
        public int SpBase
        {
            get { return _spBase; }
            set { _spBase = value; }
        }
        public int NaturalMpRegen
        {
            get { return _naturalMpRegen; }
            set { _naturalMpRegen = value; }
        }
        public int SkillAttack
        {
            get { return _skillAttack; }
            set { _skillAttack = value; }
        }
        public int SkillDefense
        {
            get { return _skillDefense; }
            set { _skillDefense = value; }
        }
        public int Dexterity
        {
            get { return _dexterity; }
            set { _dexterity = value; }
        }
        public int Spirit
        {
            get { return _spirit; }
            set { _spirit = value; }
        }
        public int Stamina
        {
            get { return _stamina; }
            set { _stamina = value; }
        }
        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        public int Mp
        {
            get { return _mp; }
            set { _mp = value; }
        }
        public int Sp
        {
            get { return _sp; }
            set { _sp = value; }
        }
    }
}
