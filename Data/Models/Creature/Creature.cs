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

        private GameStats _gameStats;
        private LifeStats _lifeStats;

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
        public GameStats GetGameStats()
        {
            return _gameStats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stats"></param>
        public void SetGameStats(GameStats stats)
        {
            _gameStats = stats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public LifeStats GetLifeStats()
        {
            return _lifeStats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lifeStats"></param>
        public void SetLifeStats(LifeStats lifeStats)
        {
            this._lifeStats = lifeStats;
        }
    }
}
