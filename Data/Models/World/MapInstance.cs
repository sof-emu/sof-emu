using Data.Models.Template.World;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Data.Models.World
{
    public class MapInstance
    {
        public MapTemplate Template { get; set; }
        private Dictionary<int, Player.Player> Players;
        private Dictionary<int, Npc.Npc> Npcs;

        public object CreaturesLock = new object();

        /// <summary>
        /// 
        /// </summary>
        public MapInstance()
        {
            Players = new Dictionary<int, Player.Player>();
            Npcs = new Dictionary<int, Npc.Npc>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        public void AddCreature(Creature.Creature creature)
        {
            Log.Debug($"AddCreature object id = {creature.ObjectId}");
            if(creature is Player.Player)
                Players.Add(creature.ObjectId, (Player.Player)creature);
            else if(creature is Npc.Npc)
                Npcs.Add(creature.ObjectId, (Npc.Npc)creature);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Player.Player GetPlayer(int id)
        {
            return Players[id];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Player.Player> GetPlayers()
        {
            return Players
                .Values
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Npc.Npc GetNpc(int id)
        {
            return Npcs[id];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Npc.Npc> GetNpcs()
        {
            return Npcs
                .Values
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void OnMove(Player.Player player)
        {
            
        }
    }
}
