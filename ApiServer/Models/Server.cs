namespace ApiServer.Models
{
    public class Server
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public List<Channel>? Channels { get; set; }
    }
}
