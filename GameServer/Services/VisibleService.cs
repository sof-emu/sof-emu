using Communicate.Interfaces;
using Data.Interfaces;
using Data.Models.Creature;
using Data.Models.Player;
using System.Linq;

namespace GameServer.Services
{
    public class VisibleService : IVisibleService
    {
        public void Action()
        {

        }

        public void Broadcast(Creature creature, ISendPacket packet)
        {
            Player player = creature as Player;

            if (player != null)
                if (player.GetSession() != null)
                    packet.Send(player.GetSession());

            player
                .GetMap()
                .GetPlayers()
                .Where(p => p.ObjectId != creature.ObjectId)
                .ToList()
                .ForEach(p => packet.Send(p.GetSession()));
        }
    }
}
