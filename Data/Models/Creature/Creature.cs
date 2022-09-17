using Data.Models.World;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data.Models.Creature
{
    public class Creature : VisibleObject
    {
        [JsonIgnore]
        public List<Player.Player> VisiblePlayers = new List<Player.Player>();

        private MapInstance Map;
        private Creature _target;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MapInstance GetMap()
        {
            return Map;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        public void SetMap(MapInstance map)
        {
            Map = map;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Creature GetTarget()
        {
            return _target;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        public void SetTarget(Creature creature)
        {
            _target = creature;
        }
    }
}
