namespace Data.Structures.Template.Server
{
    public class ChannelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Port { get; set; }
        public int Type { get; set; }
        public int MaxPlayer { get; set; }
        public int CurrentPlayerOnline { get; set; }

        public ChannelModel(int id, string name, int port, int type, int maxPlayer, int currentPlayerOnline)
        {
            Id = id;
            Name = name;
            Port = port;
            Type = type;
            MaxPlayer = maxPlayer;
            CurrentPlayerOnline = currentPlayerOnline;
        }
    }
}