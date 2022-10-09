using Data.Structures.Template.Server;
using System.Collections.Generic;
using System.IO;

namespace LobbyServer.Networks.Packets
{
    public class ResponseServerList : ASendPacket
    {
        protected List<ServerModel> servers;

        public ResponseServerList(List<ServerModel> srvs)
        {
            servers = srvs;
        }

        public override void Write(BinaryWriter writer)
        {
            WriteH(writer, servers.Count);

            foreach (var sv in servers)
            {
                WriteH(writer, sv.Id);
                WriteS(writer, sv.Name);
                WriteH(writer, 0);
                WriteH(writer, 0);
                WriteH(writer, 1);

                WriteH(writer, sv.Channels.Count);

                foreach (var ch in sv.Channels)
                {
                    int online = ch.CurrentPlayerOnline; // todo get user online in channel
                    int percent = ((online * 100) / ch.MaxPlayer);
                    WriteH(writer, ch.Id);
                    WriteS(writer, ch.Name);
                    WriteC(writer, (byte)percent);
                    WriteC(writer, (byte)ch.Type);
                }
            }
        }
    }
}
