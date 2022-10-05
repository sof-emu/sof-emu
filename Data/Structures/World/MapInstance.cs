using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
