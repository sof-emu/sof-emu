using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseSkillEffect : ASendPacket
    {
        protected int objectId;
        protected int effectId;

        public ResponseSkillEffect(int objectId, int effectId)
        {
            this.objectId = objectId;
            this.effectId = effectId;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteD(writer, objectId); // object id
            WriteD(writer, effectId); // effect id
            WriteD(writer, 0);
        }
    }
}
