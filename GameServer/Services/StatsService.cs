using Communicate.Interfaces;
using Data.Enums;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.Template.Item;
using System.Collections.Generic;
using Utility;

namespace GameServer.Services
{
    public class StatsService : IStatsService
    {
        public static Dictionary<PlayerClass, Dictionary<int, CreatureBaseStats>> PlayerStats = new Dictionary<PlayerClass, Dictionary<int, CreatureBaseStats>>();

        public void Action()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public CreatureBaseStats GetBaseStats(Player player)
        {
            return PlayerStats[player.Job][player.GetLevel()];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="npc"></param>
        /// <returns></returns>
        private CreatureBaseStats GetNpcStats(Npc npc)
        {
            return new CreatureBaseStats()
            {
                HpBase = npc.NpcTemplate.Hp,
                Attack = npc.NpcTemplate.Attack,
                Defense = npc.NpcTemplate.Defense,
                Exp = npc.NpcTemplate.Exp,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            for (int i = 1; i <= 13; i++)
            {
                PlayerStats.Add((PlayerClass)i, new Dictionary<int, CreatureBaseStats>());

                CreatureBaseStats firstLevelStats = Data.Data.StatsTemplates[(PlayerClass)i];

                for (int j = 1; j < 130; j++)
                {
                    CreatureBaseStats stats = firstLevelStats.Clone();

                    switch (stats.PlayerClass)
                    {
                        case PlayerClass.Blademan:
                            stats.HpBase += (j * 12);
                            stats.MpBase += (j * 2);
                            stats.Spirit += j;
                            stats.Strength += j + ((j % 2 == 0) ? 2 : 1);
                            stats.Stamina += j + ((j % 2 == 0) ? 2 : 1);
                            stats.Dexterity += j;
                            stats.Attack += j + ((j % 2 == 0) ? 2 : 1);
                            stats.Defense += j;
                            stats.Accuracy += j;
                            stats.Dodge += j;
                            break;
                        case PlayerClass.Swordman:
                            stats.HpBase += (j * 12);
                            stats.MpBase += (j * 2);
                            stats.Spirit += j + ((j % 2 == 0) ? 2 : 1);
                            stats.Strength += j;
                            stats.Stamina += (j * 2);
                            stats.Dexterity += (j * 2);
                            stats.Attack += (j * 2);
                            stats.Defense += j;
                            stats.Accuracy += (j * 2);
                            stats.Dodge += (j * 2);
                            break;
                        case PlayerClass.Spearman:
                            stats.HpBase += (j * 12);
                            stats.MpBase += (j * 2);
                            stats.Spirit += j;
                            stats.Strength += j;
                            stats.Stamina += (j * 3);
                            stats.Dexterity += j;
                            stats.Attack += (j * 3);
                            stats.Defense += j;
                            stats.Accuracy += j;
                            stats.Dodge += j;
                            break;
                        case PlayerClass.Bowman:
                            stats.HpBase += (j * 12);
                            stats.MpBase += (j * 2);
                            stats.Spirit += (j * 2);
                            stats.Strength += j;
                            stats.Stamina += j + ((j % 2 == 0) ? 2 : 3);
                            stats.Dexterity += (j * 3);
                            stats.Attack += j + ((j % 2 == 0) ? 2 : 3);
                            stats.Defense += j;
                            stats.Accuracy += (j * 3);
                            stats.Dodge += (j * 3);
                            break;
                        case PlayerClass.Healer:
                            stats.HpBase += (j * 7);
                            stats.MpBase += (j * 6);
                            stats.Spirit += (j * 3);
                            stats.Strength += (j * 2);
                            stats.Stamina += (j * 2);
                            stats.Dexterity += j;
                            stats.Attack += (j * 2);
                            stats.Defense += j;
                            stats.Accuracy += j;
                            stats.Dodge += j;
                            break;
                        case PlayerClass.Ninja:
                            stats.HpBase += (j * 10);
                            stats.MpBase += (j * 4);
                            stats.Spirit += (j * 2);
                            stats.Strength += (j * 2);
                            stats.Stamina += j + ((j % 2 == 0) ? 1 : 2);
                            stats.Dexterity += (j * 3);
                            stats.Attack += j + ((j % 2 == 0) ? 2 : 3);
                            stats.Defense += j;
                            stats.Accuracy += j;
                            stats.Dodge += (j * 2);
                            break;
                        case PlayerClass.Busker: // Temp copy from medic
                            stats.HpBase += (j * 7);
                            stats.MpBase += (j * 6);
                            stats.Spirit += (j * 3);
                            stats.Strength += (j * 2);
                            stats.Stamina += (j * 2);
                            stats.Dexterity += j;
                            stats.Attack += (j * 2);
                            stats.Defense += j;
                            stats.Accuracy += j;
                            stats.Dodge += j;
                            break;
                        case PlayerClass.Hanbia:
                            stats.HpBase += (j * 12);
                            stats.MpBase += (j * 2);
                            stats.Spirit += j;
                            stats.Strength += j + ((j % 2 == 0) ? 1 : 2);
                            stats.Stamina += j + ((j % 2 == 0) ? 1 : 2);
                            stats.Dexterity += j;
                            stats.Attack += j + ((j % 2 == 0) ? 1 : 2);
                            stats.Defense += j + ((j % 2 == 0) ? 1 : 2);
                            stats.Accuracy += j + ((j % 4 == 0) ? 1 : 2);
                            stats.Dodge += j + ((j % 2 == 0) ? 1 : 2);
                            break;
                        case PlayerClass.DamHwalyn:
                            stats.HpBase += (j * 12);
                            stats.MpBase += (j * 2);
                            stats.Spirit += j;
                            stats.Strength += j + ((j % 2 == 0) ? 2 : 1);
                            stats.Stamina += j + ((j % 2 == 0) ? 2 : 1);
                            stats.Dexterity += j;
                            stats.Attack += j + ((j % 2 == 0) ? 2 : 1);
                            stats.Defense += j;
                            stats.Accuracy += j;
                            stats.Dodge += j;
                            break;
                        case PlayerClass.Fighter:
                            stats.HpBase += (j * 12);
                            stats.MpBase += (j * 2);
                            stats.Spirit += j + ((j % 2 == 0) ? 2 : 1);
                            stats.Strength += j;
                            stats.Stamina += (j * 2);
                            stats.Dexterity += (j * 2);
                            stats.Attack += (j * 2);
                            stats.Defense += j;
                            stats.Accuracy += (j * 2);
                            stats.Dodge += (j * 2);
                            break;
                        case PlayerClass.MaeYujin:
                            stats.HpBase += (j * 12);
                            stats.MpBase += (j * 2);
                            stats.Spirit += (j * 2);
                            stats.Strength += j;
                            stats.Stamina += j + ((j % 2 == 0) ? 2 : 3);
                            stats.Dexterity += (j * 3);
                            stats.Attack += j + ((j % 2 == 0) ? 2 : 3);
                            stats.Defense += j;
                            stats.Accuracy += (j * 3);
                            stats.Dodge += (j * 3);
                            break;
                        case PlayerClass.Noho:
                            stats.HpBase += (j * 12);
                            stats.MpBase += (j * 2);
                            stats.Spirit += j;
                            stats.Strength += j;
                            stats.Stamina += (j * 3);
                            stats.Dexterity += j;
                            stats.Attack += (j * 3);
                            stats.Defense += j;
                            stats.Accuracy += j;
                            stats.Dodge += j;
                            break;
                        case PlayerClass.Miko:
                            stats.HpBase += (j * 7);
                            stats.MpBase += (j * 6);
                            stats.Spirit += (j * 3);
                            stats.Strength += (j * 2);
                            stats.Stamina += (j * 2);
                            stats.Dexterity += j;
                            stats.Attack += (j * 2);
                            stats.Defense += j;
                            stats.Accuracy += j;
                            stats.Dodge += j;
                            break;
                    }

                    stats.SpBase += (j * 10);

                    PlayerStats[stats.PlayerClass].Add(j, stats);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        /// <returns></returns>
        public CreatureBaseStats InitStats(Creature creature)
        {
            Player player = creature as Player;
            if (player != null)
                return GetBaseStats(player).Clone();

            Npc npc = creature as Npc;
            if (npc != null)
                return GetNpcStats(npc);

            Log.Error("StatsService: Unknown type: {0}.", creature.GetType().Name);
            return new CreatureBaseStats();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        public void UpdateStats(Creature creature)
        {
            Player player = creature as Player;
            if (player != null)
            {
                UpdatePlayerStats(player);
                return;
            }

            Npc npc = creature as Npc;
            if (npc != null)
            {
                UpdateNpcStats(npc);
                return;
            }

            Log.Error("StatsService: Unknown type: {0}.", creature.GetType().Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        private void UpdatePlayerStats(Player player)
        {
            CreatureBaseStats baseStats = GetBaseStats(player);
            baseStats.CopyTo(player.GameStats);

            int itemsAttack = 0,
                itemsDefense = 0;

            lock (player.Inventory.ItemsLock)
            {
                foreach (var item in player.Inventory.EquipItems.Values)
                {
                    if (item == null)
                        continue;

                    ItemTemplate itemTemplate = item.ItemTemplate;

                    if (itemTemplate != null)
                    {
                        itemsAttack += itemTemplate.MinAttack;
                        itemsDefense += itemTemplate.Defense;
                    }
                }
            }

            player.GameStats.Attack = (int)(baseStats.Attack + (0.03f * baseStats.Strength + 3) + itemsAttack);
            player.GameStats.Defense = (int)(baseStats.Defense + (0.01f * baseStats.Stamina + 0.5) + itemsDefense);

            player.EffectsImpact.ResetChanges(player);
            player.EffectsImpact.ApplyChanges(player.GameStats);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="npc"></param>
        private void UpdateNpcStats(Npc npc)
        {
            npc.EffectsImpact.ResetChanges(npc);
            npc.EffectsImpact.ApplyChanges(npc.GameStats);
        }
    }
}
