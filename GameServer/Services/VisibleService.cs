using Communicate.Interfaces;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Player;

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
                if (player.Session != null)
                    packet.Send(player.Session);

            //todo broadcast to nearest player

            //player
            //    .GetMap()
            //    .GetPlayers()
            //    .ForEach(p => packet.Send(p.GetSession()));
        }
    }
}
