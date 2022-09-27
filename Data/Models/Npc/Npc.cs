using Data.Models.Creature;
using Data.Models.Template.Creatures;
using Data.Models.Template.World;

namespace Data.Models.Npc
{
    public class Npc : Creature.Creature
    {
        private NpcTemplate npcTemplate;
        private SpawnTemplate spawnTemplate;

        public Npc(int objId, NpcTemplate template, SpawnTemplate spawn)
        {
            ObjectId = objId;
            npcTemplate = template;
            spawnTemplate = spawn;

            SetGameStats(new GameStats()
            {
                HpBase = npcTemplate.Hp,
                MpBase = 0,
                Attack = npcTemplate.Attack,
                Defense = npcTemplate.Defense
            });
            SetLifeStats(new LifeStats(this));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public NpcTemplate GetNpcTemplate()
        {
            return npcTemplate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SpawnTemplate GetSpawnTemplate()
        {
            return spawnTemplate;
        }
    }
}
