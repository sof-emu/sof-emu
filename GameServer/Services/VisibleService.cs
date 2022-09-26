using Communicate.Interfaces;
using Data.Interfaces;
using Data.Models.Creature;
using Data.Models.Player;

namespace GameServer.Services
{
    public class VisibleService : IVisibleService
    {
        public void Broadcast(Creature creature, ISendPacket packet)
        {
            Player player = creature as Player;
            if (player != null)
                if (player.GetSession() != null)
                    packet.Send(player.GetSession());

            if(creature.VisiblePlayers.Count > 0)
                creature
                    .VisiblePlayers
                    .ForEach(p => packet.Send(p.GetSession()));
        }

        public void Action()
        {
            
        }
    }
}
