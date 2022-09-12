using System.Collections.Generic;

namespace Data.Models.World
{
    public class MapInstance
    {
        public List<Player.Player> Players = new List<Player.Player>();

        public object CreaturesLock = new object();
    }
}
