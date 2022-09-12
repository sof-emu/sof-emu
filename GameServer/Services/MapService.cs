using Communicate.Interfaces;
using Data.Models.Creature;
using Data.Models.Player;
using Data.Models.World;
using System.Collections.Generic;

namespace GameServer.Services
{
    public class MapService : IMapService
    {
        protected Dictionary<int, MapInstance> Maps = new Dictionary<int, MapInstance>();
        public static object MapLock = new object();

        public void Action()
        {
            
        }

        public void Init()
        {
            // todo: Start Map Instance from map data templater
            // load map data from json
            // load spawn templater
        }

        public void EnterWorld(Player player)
        {
            if (!Maps.ContainsKey(player.Position.MapId))
                lock (MapLock)
                    Maps.Add(player.Position.MapId, new MapInstance());

            
            MapInstance map = Maps[player.Position.MapId];
            SpawnCreature(player, map);

            // todo
        }

        private void SpawnCreature(Creature creature, MapInstance map)
        {
            if (creature != null)
            {
                lock (map.CreaturesLock)
                {
                    if (creature is Player)
                        map.Players.Add((Player)creature);
                }

                creature.SetMap(map);
            }
        }
    }
}
