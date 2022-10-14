using Communicate.Interfaces;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Player;
using Utility.Extension;

namespace GameServer.Services
{
    public class VisibleService : IVisibleService
    {
        public void Action()
        {

        }

        public void Send(Creature creature, ISendPacket packet)
        {
            Player player = creature as Player;
            if (player != null)
            {
                if (player.Session != null)
                    packet.Send(player.Session);
            }

            creature.VisiblePlayers.Each(p => packet.Send(p.Session));
        }
    }
}
