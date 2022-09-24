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

        private BaseStats _stats;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseStats GetStats()
        {
            return _stats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stats"></param>
        public void SetStats(BaseStats stats)
        {
            if (stats.Hp == 0)
                stats.Hp = stats.HpBase;
            if (stats.Mp == 0)
                stats.Mp = stats.MpBase;
            if (stats.Sp == 0)
                stats.Sp = stats.SpBase;

            _stats = stats;
        }
    }
}
