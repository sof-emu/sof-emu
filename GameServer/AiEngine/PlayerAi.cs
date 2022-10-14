using Communicate;
using Communicate.Logics;
using Data.Enums;
using Data.Structures.Creature;
using GameServer.Controllers;
using Utility;

namespace GameServer.AiEngine
{
    class PlayerAi : DefaultAi
    {
        public long NextRegenUts;

        public long NextDistressUts;

        public long LastBattleUts;

        public override void Init(Creature creature)
        {
            base.Init(creature);

            NextRegenUts = Funcs.GetCurrentMilliseconds() + 1000;
            NextDistressUts = Funcs.GetCurrentMilliseconds() + 60000;
            LastBattleUts = 0;
        }

        public override void OnAttack(Creature target)
        {
            if (Player.Controller is DeathController)
                return;

            if (!(Player.Controller is BattleController))
                Global.ControllerService.SetController(Player, new BattleController());

            Player.Target = target;
        }

        public override void OnAttacked(Creature attacker, int damage)
        {
            if (Player.Controller is DeathController)
                return;

            if (!(Player.Controller is BattleController))
                Global.ControllerService.SetController(Player, new BattleController());

            ((BattleController)Player.Controller).AddTarget(attacker);
        }

        public override void Action()
        {
            if (Player.Controller is DeathController)
                return;

            long now = Funcs.GetCurrentMilliseconds();

            if (Player.Controller is BattleController)
            {
                LastBattleUts = now;
                Player.Controller.Action();
            }

            while (now >= NextRegenUts)
            {
                Regenerate();
                NextRegenUts += Player.Controller is BattleController ? 6000 : 3000;
            }
        }

        protected void Regenerate()
        {
            switch (Player.Job)
            {
                default:
                    int regenRate = 100;
                    switch (Player.PlayerMode)
                    {
                        case PlayerMode.Relax: regenRate = 10; break;
                        case PlayerMode.Normal: regenRate = 80; break;
                        case PlayerMode.Armored: regenRate = 140; break;
                    }

                    if (Player.LifeStats.Hp < Player.MaxHp)
                        CreatureLogic.HpChanged(Player, Player.LifeStats.PlusHp(Player.MaxHp / regenRate));

                    if (Player.LifeStats.Mp < Player.MaxMp)
                        CreatureLogic.MpChanged(Player, Player.LifeStats.PlusMp(Player.MaxMp * Player.GameStats.NaturalMpRegen / regenRate));
                    break;
            }
        }

        public override void DistanceToCreatureRecalculated(Creature creature, double distance)
        {
            
        }
    }
}
