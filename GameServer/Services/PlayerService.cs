using Communicate;
using Communicate.Interfaces;
using Communicate.Logics;
using Data.Enums;
using Data.Interfaces;
using Data.Structures.Account;
using Data.Structures.Player;
using Data.Structures.World;
using GameServer.Networks.Packets.Response;
using System.Collections.Generic;

namespace GameServer.Services
{
    public class PlayerService : IPlayerService
    {
        public static List<Player> PlayersOnline = new List<Player>();

        public void Action()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public void SendPlayerLists(ISession session)
        {
            if (session.Account.Players.Count > 0)
            {
                session.Account.Players.ForEach(player =>
                {
                    new ResponsePlayerList(player).Send(session);
                });
            }
            else
                new ResponsePlayerList().Send(session);
        }

        /// <summary>
        /// Check exist character name
        /// and then send Response to client
        /// </summary>
        /// <param name="session"></param>
        /// <param name="name"></param>
        public void CheckNameExist(ISession session, string name)
        {
            bool isExists = false;
            //await Global
            //    .ApiService
            //    .CheckNameExist(name);

            new ResponseCheckName(name, isExists).Send(session);
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
                    .Broadcast(player, new ResponsePlayerInfo(player));
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
            // list.ForEach(player =>
            // {
            // 
            // });

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

            // AiLogic.InitAi(player);

            PlayersOnline.Add(player);
        }
    }
}
