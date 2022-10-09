using Communicate.Interfaces;
using Data.Interfaces;
using Data.Structures.Player;
using Data.Structures.World;
using GameServer.Engines.NpcActions;
using GameServer.Networks.Packets.Response;
using System;
using System.Collections.Generic;
using Utility;

namespace GameServer.Services
{
    public class NpcService : INpcService
    {
        public static Dictionary<int, Type> Actions = new Dictionary<int, Type>();

        public NpcService()
        {
            Actions.Add(1, typeof(TalkToNpc));
            Actions.Add(2, typeof(EndTalk));
            Actions.Add(3, typeof(OpenShop));
            Actions.Add(4, typeof(QuestDialog));
            Actions.Add(5, typeof(OpenWarehouse));
            Actions.Add(6, typeof(ForgeItem));
            Actions.Add(8, typeof(EnhanceItem));
            Actions.Add(15, typeof(MoveToMarketplace));

            Log.Debug($"Actions: {Actions.Count}");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Action()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="actionId"></param>
        /// <param name="tabIndex"></param>
        public void NpcInteraction(ISession session, int shopId, int actionId, int tabIndex)
        {
            if(Actions.ContainsKey(actionId))
            {
                ((INpcAction)Activator.CreateInstance(Actions[actionId]))
                    .Execute(session, shopId, actionId, tabIndex);
            } 
            else
            {
                Log.Warn($"Notfound NpcInteraction ActionId: {actionId}");
                new ResponseNpcInteraction(shopId, actionId).Send(session);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="map"></param>
        public void SendNpcList(Player player, MapInstance map)
        {
            //Log.Debug($"player: {player.Id}, MapId: {map.Template.Id}, Npcs: {map.GetNpcs().Count}");
            //List<Npc> npcs =  map.GetNpcs();
            //new ResponseNpcSpawn(npcs).Send(player.GetSession());
        }
    }
}
