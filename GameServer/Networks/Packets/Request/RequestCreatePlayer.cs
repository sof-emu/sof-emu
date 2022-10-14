using Communicate;
using Communicate.Logics;
using Data.Enums;
using Utility;

namespace GameServer.Networks.Packets.Request
{
    public class RequestCreatePlayer : ARecvPacket
    {
        protected string Name;
        protected PlayerClass playerClass;
        protected string HairColor;
        protected int Voice;
        protected int Gender;

        public override void ExecuteRead()
        {
            Name = ReadS(16).Replace("\0", "");
            playerClass = (PlayerClass)ReadC(); // Class
            ReadC(); // ?
            HairColor = ReadB(2).ToHex(); // Hair Color
            ReadC(); // ? 1
            Voice = ReadC(); // ? voice
            Gender = ReadC(); // gender
        }

        public override void Process()
        {
            PlayerLogic.CreatePlayer(session, Name, playerClass, HairColor, Voice, Gender);
        }
    }
}
