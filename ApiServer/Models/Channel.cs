namespace ApiServer.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Port { get; set; }
        public int Type { get; set; }
        public int MaxPlayer { get; set; }
        public int CurrentPlayerOnline { get; set; }

    }
}
