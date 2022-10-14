using Data.Interfaces;
using Data.Structures.Player;

namespace GameServer.Controllers
{
    class DefaultController : IController
    {
        public Player Player;

        public void Action()
        {
            
        }

        public void Release()
        {
            Player = null;
        }

        public void Start(Player player)
        {
            Player = player;
        }
    }
}
