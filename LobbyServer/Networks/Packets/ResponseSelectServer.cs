using Data.Models.Server;
using System.IO;

namespace LobbyServer.Networks.Packets
{
    public class ResponseSelectServer : ASendPacket
    {
        protected ServerModel server;
        protected ChannelModel channel;

        public ResponseSelectServer(ServerModel srv, ChannelModel chn)
        {
            server = srv;
            channel = chn;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteS(writer, server.Address);
            WriteH(writer, channel.Port);
            WriteS(writer, channel.Name);
            WriteS(writer, channel.Name);
        }
    }
}
