using Communicate.Interfaces;
using Data.Models.Npc;
using Data.Models.Player;
using Data.Models.World;
using GameServer.Networks.Packets.Response;
using System.Collections.Generic;

namespace GameServer.Services
{
    public class NpcService : INpcService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="map"></param>
        public void SendNpcList(Player player, MapInstance map)
        {
            //Log.Debug($"player: {player.Id}, MapId: {map.Template.Id}, Npcs: {map.GetNpcs().Count}");
            List<Npc> npcs =  map.GetNpcs();
            new ResponseNpcSpawn(npcs).Send(player.GetSession());
        }

        /// <summary>
        /// 
        /// </summary>
        public void Action()
        {

        }
    }
}
