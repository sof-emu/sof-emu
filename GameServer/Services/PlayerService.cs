using Communicate;
using Communicate.Interfaces;
using Communicate.Logics;
using Data.Enums;
using Data.Interfaces;
using Data.Structures.Account;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.World;
using GameServer.Networks.Packets.Response;
using System;
using System.Collections.Generic;
using System.Threading;
using Utility;

namespace GameServer.Services
{
    public class PlayerService : IPlayerService
    {
        public static List<Player> PlayersOnline = new List<Player>();

        public void Action()
        {
            for (int i = 0; i < PlayersOnline.Count; i++)
            {
                try
                {
                    if (PlayersOnline[i].Ai != null)
                        PlayersOnline[i].Ai.Action();

                    if (PlayersOnline[i].Visible != null)
                        PlayersOnline[i].Visible.Update();

                    if (PlayersOnline[i].Controller != null)
                        PlayersOnline[i].Controller.Action();
                }
                catch (Exception ex)
                {
                    //Collection modified
                    Log.ErrorException("PlayerService.Action:", ex);
                }

                if ((i & 511) == 0) // 2^N - 1
                    Thread.Sleep(1);
            }
        }

        /// <summary>
        /// Create Player data and send to ApiServer
        /// Waiting response to send resutl to client
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        /// <param name="playerClass"></param>
        /// <param name="hairColor"></param>
        /// <param name="voice"></param>
        /// <param name="gender"></param>
        public Player CreatePlayer(ISession session, string name, PlayerClass playerClass, string hairColor, int voice, int gender)
        {
            Player player = new Player()
            {
                Name = name,
                Level = 1,
                Job = playerClass,
                JobLevel = 1,
                AccountId = session.Account.Id,
                Faction = 0,
                Appearance = new Appearance()
                {
                    HairColor = hairColor,
                    HairStyle = 0,
                    Voice = voice,
                    Gender = gender,
                },
                Position = new WorldPosition()
                {
                    MapId = 101,
                    X = 378.501f,
                    Y = 1741.1f,
                    Z = 15f
                }
            };

            player.PlayerId = Global.PlayerRepository.SavePlayer(player);
            Global.StorageService.AddStartItemsToPlayer(player);

            player.GameStats = Global.StatsService.InitStats(player);
            session.Account.Players.Add(player);
            return player;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public void OnUpdateSetting(ISession session)
        {
            var player = session.Player;

            if (player != null)
                Global
                    .VisibleService
                    .Send(player, new ResponsePlayerInfo(player));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        /// <param name="distance"></param>
        /// <param name="target"></param>
        public void PlayerMoved(Player player, float x1, float y1, float z1, float x2, float y2, float z2, float distance, int target)
        {
            if (target != 65535)
            {
                /*Creature Target = player
                    .GetMap()
                    .GetNpc(target);

                player.SetTarget(Target);*/
            }


            player.Position.X = x1;
            player.Position.Y = y1;

            player.Position.X2 = x2;
            player.Position.Y2 = y2;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public List<Player> OnAuthorized(Account account)
        {
            var list = Global.PlayerRepository.GetPlayerFromAccountId(account.Id);

            // todo load player inventory, quests, skills
            list.ForEach(player =>
            {
                player.GameStats = Global.StatsService.InitStats(player);
            });

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void InitPlayer(Player player)
        {
            player.Level = 1;

            while((player.Level + 1) != Data.Data.PlayerExperience.Count - 1 && player.Exp >= Data.Data.PlayerExperience[player.Level])
                player.Level++;

            player.GameStats = CreatureLogic.InitGameStats(player);
            CreatureLogic.UpdateCreatureStats(player);

            AiLogic.InitAi(player);

            PlayersOnline.Add(player);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CheckNameResult CheckName(string name)
        {
            if (Global.PlayerRepository.NameExists(name))
                return CheckNameResult.Unavailable;

            return CheckNameResult.Ok;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool IsPlayerOnline(Player player)
        {
            return PlayersOnline.Contains(player);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="exp"></param>
        /// <param name="npc"></param>
        public void AddExp(Player player, int exp, Npc npc)
        {
            exp *= 1; //Rate.EXP;

            //todo rate modifiers
            if (player.GetLevel() >= 130) // Rate.LEVEL_CAP
            {
                //new SpSystemNotice("Sorry, but now, level cap is " + GamePlay.Default.LevelCap).Send(player);
                return;
            }

            int val1 = npc.NpcTemplate.Exp * 1; // Rate.KI_EXP
            int val2 = val1 / 3;
            int ki = Funcs.Random().Next(val1 - val2, val1 + val2);
            player.SkillPoint += ki;

            SetExp(player, player.Exp + exp, npc);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="add"></param>
        /// <param name="npc"></param>
        public void SetExp(Player player, long add, Npc npc)
        {

            int maxLevel = Data.Data.PlayerExperience.Count - 1;

            long maxExp = Data.Data.PlayerExperience[maxLevel - 1];
            int level = 1;


            if (add > maxExp)
                add = maxExp;

            while ((level + 1) != maxLevel && add >= Data.Data.PlayerExperience[level])
            {
                level++;
            }

            long added = add - player.Exp;

            if (level != player.Level)
            {
                player.Level = level;
                player.Exp = add;
                player.AbilityPoint += 1;
                PlayerLogic.LevelUp(player);
            }
            else
                player.Exp = add;

            new ResponsePlayerExpPoint(player, added, npc).Send(player.Session);
        }

        
    }
}
