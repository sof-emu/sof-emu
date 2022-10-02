using Data.Models.Creature;
using Data.Models.Template.Creatures;
using Data.Models.Template.World;

namespace Data.Models.Npc
{
    public class Npc : Creature.Creature
    {
        private NpcTemplate template;
        private SpawnTemplate spawnTemplate;

        public Npc(int objId, NpcTemplate template, SpawnTemplate spawn)
        {
            ObjectId = objId;
            this.template = template;
            spawnTemplate = spawn;

            SetGameStats(new GameStats()
            {
                HpBase = this.template.Hp,
                MpBase = 0,
                Attack = this.template.Attack,
                Defense = this.template.Defense
            });
            SetLifeStats(new LifeStats(this));
            SetPosition(new World.Position()
            {
                X = spawnTemplate.X,
                Y = spawnTemplate.Y,
                Z = spawnTemplate.Z
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public NpcTemplate GetNpcTemplate()
        {
            return template;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SpawnTemplate GetSpawnTemplate()
        {
            return spawnTemplate;
        }

        /// <summary>
        /// Object is Npc or not
        /// </summary>
        /// <returns></returns>
        public bool IsNpc()
        {
            return template.Npc > 0;
        }
    }
}
