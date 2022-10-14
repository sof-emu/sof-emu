using Communicate;
using Communicate.Logics;
using Data.Structures.Creature;
using Data.Structures.Player;
using GameServer.Controllers;
using System;
using Utility;
using Utility.Extension;

namespace GameServer.AiEngine
{
    class NpcAi : DefaultAi
    {
        protected const int ActionInterval = 1000;

        public NpcMoveController MoveController;

        public NpcBattleController BattleController;

        protected long LastCallUts = Funcs.GetCurrentMilliseconds();

        protected long LastWalkUts;

        protected long NextChangeDirectionUts;

        protected long RespawnUts = 0;

        protected Player PlayerInFocus;

        public int AgroDistance = 75;

        public override void Init(Creature creature)
        {
            base.Init(creature);

            MoveController = new NpcMoveController(Npc);
            BattleController = new NpcBattleController(Npc);
        }

        public override void Release()
        {
            base.Release();

            if (MoveController != null)
                MoveController.Release();
            MoveController = null;

            if (BattleController != null)
                BattleController.Release();
            BattleController = null;
        }

        public override void OnAttacked(Creature attacker, int damage)
        {
            Npc.Target = attacker;

            BattleController.AddDamage(attacker, damage);
            BattleController.AddAggro(attacker, damage);
        }

        public override Creature GetKiller()
        {
            return BattleController.GetKiller();
        }

        public override void DealExp()
        {
            BattleController.DealExp();
        }

        //Actions:

        public override void Action()
        {
            if (Npc.NpcTemplate.Npc == 1)
                return;

            long now = Funcs.GetCurrentMilliseconds();

            if (Npc.LifeStats.IsDead())
            {
                if (RespawnUts == 0)
                {
                    CreatureLogic.NpcDied(Npc);
                    RespawnUts = now + 20000;
                    return;
                }

                if (now < RespawnUts || Global.MapService.IsDungeon(Npc.Position.MapId))
                    return;

                RespawnUts = 0;
                Npc.BindPoint.CopyTo(Npc.Position);

                MoveController.Reset();
                BattleController.Reset();

                Npc.LifeStats.Rebirth();
            }

            long elapsed = now - LastCallUts;
            LastCallUts = now;

            MoveController.Action(elapsed);
            BattleController.Action();

            //if (Npc.VisiblePlayers.Count < 1) return;

            EnemiesListenAction();

            if (NextChangeDirectionUts < now)
                RandomWalkAction();
        }

        protected void EnemiesListenAction()
        {
            if (Npc.VisiblePlayers.Count < 1)
                return;

            if (Npc.Target != null || Npc.LifeStats.IsDead())
            {
                PlayerInFocus = null;
                return;
            }

            if (PlayerInFocus != null)
                if (PlayerInFocus.Position.DistanceTo(Npc.Position) > AgroDistance || PlayerInFocus.LifeStats.IsDead())
                    PlayerInFocus = null;

            Npc.VisiblePlayers.Each(
                player =>
                {
                    if (PlayerInFocus != null
                        || player.LifeStats.IsDead()
                        || player.Position.DistanceTo(Npc.Position) > AgroDistance)
                        return;

                    OnCreatureApproached(player);
                });
        }

        protected void OnCreatureApproached(Player player)
        {
            PlayerInFocus = player;

            if (!BattleController.IsHateCreature(player))
            {
                //if (Npc.NpcTemplate.Level >= 20)
                //    OnAttacked(creature, 0);
            }
        }

        protected void RandomWalkAction()
        {
            if (Npc.Target != null || MoveController.IsActive)
                return;

            if (Npc.Attack != null && !Npc.Attack.IsFinished)
                return;

            long now = Funcs.GetCurrentMilliseconds();

            if (now - 10000 < LastWalkUts)
                return;

            LastWalkUts = Funcs.GetCurrentMilliseconds() + Random.Next(5000, 10000);

            if (Random.Next(0, 100) < 50)
                return;

            double distanceToBind = Npc.BindPoint.DistanceTo(Creature.Position);
            if (distanceToBind > 100)
            {
                MoveController.MoveTo(Creature.BindPoint);
                return;
            }

            MoveController.MoveTo(Npc.Position.X
                                  + Random.Next(50, 100)
                                  * (Random.Next(0, 100) < 50 ? 1 : -1)
                                  ,
                                  Npc.Position.Y
                                  + Random.Next(50, 100)
                                  * (Random.Next(0, 100) < 50 ? 1 : -1));
        }
    }
}
