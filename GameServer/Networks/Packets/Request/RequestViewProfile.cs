using Communicate.Logics;
using Utility;

namespace GameServer.Networks.Packets.Request
{
    public class RequestViewProfile : ARecvPacket
    {
        protected int ProfileId;

        public override void ExecuteRead()
        {
            ProfileId = ReadD();
        }

        public override void Process()
        {
            Log.Debug($"Profile ID = {ProfileId}");
            //GlobalLogic
            //    .ViewProfile(ProfileId);
        }
    }
}
