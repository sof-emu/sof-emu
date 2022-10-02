using Communicate;
using Communicate.Interfaces;
using Communicate.Logics;
using Data.Enums;
using Data.Models.Creature;
using Data.Models.Npc;
using Data.Models.Player;
using Data.Models.SkillEngine;
using GameServer.Engines.Utils;
using GameServer.Networks.Packets.Response;
using System;
using Utility;

namespace GameServer.Engines
{
    public class AttackEngine : IAttackEngine
    {
        public void Action()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="target"></param>
        /// <param name="args"></param>
        public void Attack(Player player, Creature target, UseSkillArgs args)
        {
            if ((target as Npc).IsNpc())
                return;

            ProcessAttack(player, target, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="target"></param>
        /// <param name="pos"></param>
        private void ProcessAttack(Creature attacker, Creature target, UseSkillArgs args)
        {
            try
            {
                if(attacker is Player)
                {
                    Player player = (Player)attacker;
                    if (player.GetState() == PlayerState.Died)
                        return;

                    if (!target.GetLifeStats().IsDead())
                    {
                        Log.Debug($"args 1 = {args.TojsonString()}");
                        player.Attack = new Attack(player,
                                                 args,
                                                 () => GlobalLogic.AttackStageEnd(player),
                                                 () => GlobalLogic.AttackFinished(player));

                        Log.Debug($"args 2 = {player.Attack.Args.TojsonString()}");

                        /*long millisec = player.LastAttackUtc + 1500;

                        if (millisec > Funcs.GetCurrentMilliseconds())
                        {
                            new DelayedAction(player
                            .Attack
                            .NextStage, 1200);
                            return;
                        }

                        player.LastAttackUtc = Funcs.GetCurrentMilliseconds();*/

                        int damage = SkillEngineUtil.CalculateDefaultAttackDamage(player, target, player.GetGameStats().Attack);

                        Global.VisibleService
                            .Broadcast(player, new ResponseAttack(player, player.Attack));

                        target.GetLifeStats().MinusHp(damage);

                        new DelayedAction(player
                            .Attack
                            .NextStage, 1200);

                        return;
                    }

                    new DelayedAction(player
                        .Attack
                        .Finish, 300);
                }
                else if(attacker is Npc)
                {
                    // todo
                }
                
            }
            catch (Exception ex)
            {
                Log.ErrorException("ProcessAttack: ", ex);
            }
        }
    }
}
