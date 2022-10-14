using Communicate.Interfaces;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using GameServer.AiEngine;
using System;

namespace GameServer.Services
{
    public class AiService : IAiService
    {
        public void Action()
        {
            
        }

        public IAi CreateAi(Creature creature)
        {
            if (creature is Player)
                return new PlayerAi();

            if (creature is Npc)
                return new NpcAi();

            return new DefaultAi();
        }
    }
}
