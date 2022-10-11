using Communicate.Interfaces;
using Data.Enums;
using Data.Structures.Creature;
using Data.Structures.Player;
using System.Collections.Generic;

namespace GameServer.Services
{
    public class StatsService : IStatsService
    {
        public static Dictionary<PlayerClass, Dictionary<int, CreatureBaseStats>> PlayerStats = new Dictionary<PlayerClass, Dictionary<int, CreatureBaseStats>>();
        public static Dictionary<int, Dictionary<int, CreatureBaseStats>> NpcStats = new Dictionary<int, Dictionary<int, CreatureBaseStats>>();

        public void Action()
        {
            
        }

        public CreatureBaseStats GetBaseStats(Player player)
        {
            return null;
        }

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

        public CreatureBaseStats InitStats(Creature creature)
        {
            return null;
        }

        public void UpdateStats(Creature creature)
        {
            
        }
    }
}
