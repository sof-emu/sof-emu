using Communicate.Interfaces;
using Data.Models.Creature;
using Data.Models.Npc;
using Data.Models.Player;
using Data.Models.Template.Creatures;
using Data.Models.World;
using System.Collections.Generic;
using System.Linq;

namespace GameServer.Services
{
    public class MapService : IMapService
    {
        protected Dictionary<int, MapInstance> Maps = new Dictionary<int, MapInstance>();
        public static object MapLock = new object();

        public void Action()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            // todo: Start Map Instance from map data templater
            // load map data from json
            // load spawn templater
            var list = Data.Data.MapTemplates.Values.ToList();
            list.ForEach(map =>
            {
                MapInstance mapInstance = new MapInstance();
                mapInstance.Template = map;

                if (Data.Data.SpawnTemplates.ContainsKey(map.Id))
                {
                    Data.Data.SpawnTemplates[map.Id].ForEach(spawn =>
                    {
                        int objId = GameServer
                            .IDFactory
                            .GetNextStatic();

                        NpcTemplate template = Data.Data.NpcTemplates[spawn.NpcId];
                        Npc npc = new Npc(objId, template, spawn);
                        SpawnCreature(npc, mapInstance);
                    });
                }

                Maps.Add(map.Id, mapInstance);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void EnterWorld(Player player)
        {
            if (!Maps.ContainsKey(player.Position.MapId))
                lock (MapLock)
                    Maps.Add(player.Position.MapId, new MapInstance());

            MapInstance map = Maps[player.Position.MapId];
            SpawnCreature(player, map);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="map"></param>
        private void SpawnCreature(Creature creature, MapInstance map)
        {
            if (creature != null)
            {
                lock (map.CreaturesLock)
                {
                    if (creature is Player)
                        map.AddCreature((Player)creature);
                    if (creature is Npc)
                        map.AddCreature((Npc)creature);
                }

                creature.SetMap(map);
            }
        }
    }
}
