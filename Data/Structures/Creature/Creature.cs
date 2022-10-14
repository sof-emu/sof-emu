using Data.Interfaces;
using Data.Structures.SkillEngine;
using Data.Structures.World;
using System.Collections.Generic;

namespace Data.Structures.Creature
{
    public abstract class Creature : RxjhObject
    {
        private CreatureLifeStats _lifeStats;

        public List<Player.Player> VisiblePlayers = new List<Player.Player>();
        public List<Npc.Npc> VisibleNpcs = new List<Npc.Npc>();
        public List<Item> VisibleItems = new List<Item>();

        public List<Player.Player> ObserversList = new List<Player.Player>();

        public IAi Ai;

        public CreatureLifeStats LifeStats
        {
            get { return _lifeStats ?? (_lifeStats = new CreatureLifeStats(this)); }
        }

        public CreatureBaseStats GameStats;

        public override int UID => base.UID;

        public int MaxHp
        {
            get { return GameStats.HpBase; }
        }

        public int MaxMp
        {
            get { return GameStats.MpBase; }
        }

        public int MaxSp
        {
            get { return GameStats.SpBase; }
        }

        public Attack Attack;
        public long LastAttackUtc;

        public WorldPosition Position;
        public WorldPosition BindPoint;
        public MapInstance Instance;

        public Creature Target;
        public List<Abnormal> Effects = new List<Abnormal>();
        public object EffectsLock = new object();
        public CreatureEffectsImpact EffectsImpact = new CreatureEffectsImpact();

        public abstract int GetLevel();
        public abstract int GetModelId();

        public override void Release()
        {
            VisiblePlayers = null;
            VisibleNpcs = null;

            if (Ai != null)
                Ai.Release();
            Ai = null;

            if (_lifeStats != null)
                _lifeStats.Release();
            _lifeStats = null;

            GameStats = null;

            Position = null;
            BindPoint = null;
            Instance = null;

            Target = null;

            base.Release();
        }
    }
}
