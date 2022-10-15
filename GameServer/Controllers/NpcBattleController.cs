using Communicate;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.SkillEngine;
using GameServer.AiEngine;
using System.Collections.Generic;
using Utility;

namespace GameServer.Controllers
{
    class NpcBattleController
    {
        public Npc Npc;

        protected Dictionary<Creature, int> Damage = new Dictionary<Creature, int>();

        protected Dictionary<Creature, int> Hate = new Dictionary<Creature, int>();

        protected object Lock = new object();

        protected long LastMoveUts = 0;

        protected long LastAttackUts = 0;

        protected Skill SelectedSkill = null;

        public NpcBattleController(Npc npc)
        {
            Npc = npc;
        }

        public void Reset()
        {
            Damage.Clear();
            Hate.Clear();
        }

        public void Release()
        {
            Npc = null;

            Damage.Clear();
            Damage = null;

            Hate.Clear();
            Hate = null;

            Lock = null;
        }

        public Creature GetKiller()
        {
            Creature creature = null;
            int maxDamage = 0;

            foreach (var d in Damage)
            {
                if (d.Value > maxDamage)
                {
                    creature = d.Key;
                    maxDamage = d.Value;
                }
            }

            return creature;
        }

        public void DealExp()
        {
            foreach (var d in Damage)
            {
                Player player = d.Key as Player;
                if (player == null)
                    continue;

                /*if (player.Party != null)
                    Global.Global.PartyService.AddExp(player, totalExp * d.Value / totalDamage);
                else*/
                Global.PlayerService.AddExp(player, Npc.NpcTemplate.Exp, Npc);
            }
        }

        public void Action()
        {
            lock (Lock)
            {
                Creature target = null;
                int maxHate = int.MinValue;

                foreach (var hate in Hate)
                {
                    if (hate.Key.Position.DistanceTo(Npc.Position) > 100 || hate.Key.LifeStats.IsDead())
                    {
                        Damage.Remove(hate.Key);
                        Hate.Remove(hate.Key);
                        return;
                    }

                    if (hate.Value > maxHate)
                    {
                        target = hate.Key;
                        maxHate = hate.Value;
                    }
                }

                Npc.Target = target;
            }

            if (Npc.Target == null)
                return;

            int distance = (int)Npc.Position.DistanceTo(Npc.Target.Position);

            long now = Funcs.GetCurrentMilliseconds();

            if (distance > 10)
            {
                if (now > LastMoveUts + 2000)
                {
                    LastMoveUts = now;
                    ((NpcAi)Npc.Ai).MoveController.MoveTo(Npc.Target.Position, distance);
                }
                return;
            }

            ((NpcAi)Npc.Ai).MoveController.Stop();

            if (now > LastAttackUts + 3000 && !Npc.Target.LifeStats.IsDead())
            {
                LastAttackUts = now;
                Global.SkillEngine.UseSkill(Npc, null);
                new DelayedAction(SendUpdateHpMpSp, 100);
            }
        }

        private void SendUpdateHpMpSp()
        {
            Global.FeedbackService.HpMpSpChanged(Npc.Target as Player);
        }

        public void AddDamage(Creature attacker, int damage)
        {
            lock (Lock)
            {
                if (!Damage.ContainsKey(attacker))
                    Damage.Add(attacker, damage);
                else
                    Damage[attacker] += damage;
            }
        }

        public void AddAggro(Creature attacker, int hate)
        {
            lock (Lock)
            {
                if (!Hate.ContainsKey(attacker))
                    Hate.Add(attacker, hate);
                else
                    Hate[attacker] += hate;
            }
        }

        public bool IsHateCreature(Creature creature)
        {
            return Hate.ContainsKey(creature);
        }
    }
}
