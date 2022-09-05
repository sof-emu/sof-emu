using Data.Interfaces;
using System.Collections.Generic;

namespace Data.Models.Server
{
    public class ServerModel : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Dictionary<int, ChannelModel> Channels;

        public ServerModel(int id, string name, string address, Dictionary<int, ChannelModel> channels)
        {
            Id = id;
            Name = name;
            Address = address;
            Channels = channels;
        }
    }
}
