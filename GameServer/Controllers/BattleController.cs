using Communicate;
using Communicate.Logics;
using Data.Enums;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Player;
using System.Collections.Generic;
using Utility;

namespace GameServer.Controllers
{
    internal class BattleController : IController
    {
        public const int Timeout = 15000;

        protected long LastAttackUts = 0;

        protected long LastRageUts = 0;

        protected Player Player;

        protected Dictionary<Creature, long> Targets = new Dictionary<Creature, long>();

        protected object TargetsLock = new object();

        public void AddTarget(Creature creature)
        {
            lock (TargetsLock)
            {
                if (Targets == null)
                    Targets = new Dictionary<Creature, long>();

                if (!Targets.ContainsKey(creature))
                {
                    Targets.Add(creature, Funcs.GetCurrentMilliseconds());
                }
                else
                    UpdateTarget(creature);
            }
        }

        public void Start(Player player)
        {
            Player = player;

            player.PlayerMode = PlayerMode.Armored;

            CreatureLogic.UpdateCreatureStats(Player);
        }

        public void Release()
        {
            if (Player != null)
            {
                Player.PlayerMode = PlayerMode.Normal;

                CreatureLogic.UpdateCreatureStats(Player);
            }

            Player = null;
            Targets.Clear();
            Targets = null;
        }

        public void Action()
        {
            if (Player.LifeStats.IsDead())
            {
                Global.ControllerService.SetController(Player, new DeathController());
                return;
            }

            if (Player.Target == null)
            {
                Global.ControllerService.SetController(Player, new DefaultController());
                return;
            }

            long now = Funcs.GetCurrentMilliseconds();
            if (Player.LifeStats.IsRage())
            {
                LastRageUts = now;
                Player.IsRage = true;
            }

            if (Player.IsRage)
            {
                if (LastRageUts + Player.GameStats.RageModeDuration < now)
                {
                    Log.Debug("Stop Rage !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Player.IsRage = false;
                }
            }
        }

        public bool Contains(Creature creature)
        {
            return Targets.ContainsKey(creature);
        }

        public void RemoveTarget(Creature creature)
        {
            if (Contains(creature))
                lock (TargetsLock)
                {
                    Targets.Remove(creature);
                    Global.ObserverService.RemoveObserved(Player, creature);
                }
        }

        public void UpdateTarget(Creature creature)
        {
            if (Contains(creature))
                lock (TargetsLock)
                    Targets[creature] = Funcs.GetCurrentMilliseconds();
        }
    }
}
