namespace Data.Models.Creature
{
    public class LifeStats
    {
        public Creature Creature;

        public LifeStats(Creature creature)
        {
            _hp = creature.GetGameStats().HpBase;
            _mp = creature.GetGameStats().MpBase;
            _sp = 0;

            Creature = creature;
        }

        private int _hp;

        public int Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }

        private int _mp;

        public int Mp
        {
            get { return _mp; }
            set { _mp = value; }
        }

        private int _sp;

        public int Sp
        {
            get { return _sp; }
            set { _sp = value; }
        }

        public int MaxHp
        {
            get { return Creature.GetGameStats().HpBase; }
        }

        public int MaxMp
        {
            get { return Creature.GetGameStats().MpBase; }
        }

        public int MaxSp
        {
            get { return Creature.GetGameStats().SpBase; }
        }

        public bool IsDead()
        {
            if (Hp <= 0)
                return true;

            return false;
        }

        public bool IsRage()
        {
            if (Sp >= Creature.GetGameStats().SpBase)
            {
                Sp = 0;
                return true;
            }

            return false;
        }

        public int PlusHp(int value)
        {
            _hp += value;

            if (_hp > Creature.GetGameStats().HpBase)
            {
                value -= _hp - Creature.GetGameStats().HpBase;
                _hp = Creature.GetGameStats().HpBase;
            }

            return value;
        }

        public int GetHpDiffResult(int value)
        {
            return _hp - value;
        }

        public int MinusHp(int value)
        {
            _hp -= value;

            if (_hp < 0)
            {
                value += _hp;
                _hp = 0;
            }

            return -value;
        }

        public int PlusMp(int value)
        {
            _mp += value;

            if (_mp > Creature.GetGameStats().MpBase)
            {
                value -= _mp - Creature.GetGameStats().MpBase;
                _mp = Creature.GetGameStats().MpBase;
            }

            return value;
        }

        public int MinusMp(int value)
        {
            _mp -= value;

            if (_mp < 0)
            {
                value += _mp;
                _mp = 0;
            }

            return -value;
        }

        public int PlusSp(int value)
        {
            _sp += value;

            if (_sp > Creature.GetGameStats().SpBase)
            {
                value -= _sp - Creature.GetGameStats().SpBase;
                _sp = Creature.GetGameStats().SpBase;
            }

            return value;
        }

        public int MinusSp(int value)
        {
            _sp -= value;

            if (_sp < 0)
            {
                value += _sp;
                _sp = 0;
            }

            return -value;
        }

        public void Kill()
        {
            _hp = 0;
            _mp = 0;
            _sp = 0;

        }

        public void Rebirth()
        {
            _hp = Creature.GetGameStats().HpBase;
            _mp = Creature.GetGameStats().MpBase;

            if (Creature is Npc.Npc)
                return;

            _hp /= 10;
            _mp /= 10;
        }

        public void LevelUp()
        {
            _hp = Creature.GetGameStats().HpBase;
            _mp = Creature.GetGameStats().MpBase;
        }

        public LifeStats Clone()
        {
            return (LifeStats)MemberwiseClone();
        }

        public void Release()
        {
            Creature = null;
        }
    }
}
