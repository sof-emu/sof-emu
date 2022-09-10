using Data.Interfaces;
using System.Collections.Generic;

namespace Data.Models.Creature
{
    public class Creature : VisibleObject
    {
        public List<Player.Player> VisiblePlayers = new List<Player.Player>();
    }
}
