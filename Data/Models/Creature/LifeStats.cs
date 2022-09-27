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

        public bool IsDead()
        {
            if (Hp <= 0)
                return true;

            return false;
        }
    }
}
