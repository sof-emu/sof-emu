using System.Collections.Generic;

namespace Data.Structures.World
{
    public class MapInstance : Statistical
    {
        public int MapId;

        public List<Player.Player> Players = new List<Player.Player>();
        public List<Npc.Npc> Npcs = new List<Npc.Npc>();
        public List<Item> Items = new List<Item>();
    }
}
