using Data.Interfaces;
using System.Collections.Generic;

namespace Data.Models.Server
{
    public class ServerModel : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<ChannelModel> Channels;

        public ServerModel(int id, string name, string address, List<ChannelModel> channels)
        {
            Id = id;
            Name = name;
            Address = address;
            Channels = channels;
        }
    }
}
