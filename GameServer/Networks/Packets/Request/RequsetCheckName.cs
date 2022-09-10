namespace GameServer.Networks.Packets.Request
{
    public class RequsetCheckName : ARecvPacket
    {
        protected string Name;

        public override void ExecuteRead()
        {
            Name = ReadS(15).Replace("\0", "");
        }

        public override void Process()
        {
            GameServer
                .FeedbackService
                .CheckNameExist(session, Name);
        }
    }
}
