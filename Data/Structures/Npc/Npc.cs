using Data.Structures.Template.Creature;
using Data.Structures.Template.World;
using System.Collections.Generic;

namespace Data.Structures.Npc
{
    public class Npc : Creature.Creature
    {
        public int NpcId;

        public NpcTemplate NpcTemplate;

        public SpawnTemplate SpawnTemplate;

        public Npc ParentNpc;
        public List<Npc> Childs = new List<Npc>();

        public List<Npc> NamesList;

        public override int GetLevel()
        {
            return NpcTemplate == null ? 1 : NpcTemplate.Level;
        }

        public override int GetModelId()
        {
            return NpcTemplate.Id;
        }

        public override void Release()
        {
            if (NamesList != null)
            {
                NamesList.Remove(this);
                NamesList = null;
            }

            base.Release();
        }

        public Npc Clone()
        {
            Npc clone = new Npc
            {
                NpcId = NpcId,
                SpawnTemplate = SpawnTemplate,
                NpcTemplate = NpcTemplate,
                Position = Position.Clone(),
                BindPoint = BindPoint.Clone(),
            };

            return clone;
        }
    }
}
