using Data.Structures.Template.Creature;
using Data.Structures.Template.World;

namespace Data.Structures.Npc
{
    public class Npc : Creature.Creature
    {
        private NpcTemplate template;
        private SpawnTemplate spawnTemplate;

        public Npc(NpcTemplate template, SpawnTemplate spawnTemplate)
        {
            this.template = template;
            this.spawnTemplate = spawnTemplate;
        }

        public int NpcId
        {
            get { return template.Id; }
        }

        public SpawnTemplate Spawn { get { return spawnTemplate; } }

        public override int GetLevel()
        {
            return 1;
        }
    }
}
