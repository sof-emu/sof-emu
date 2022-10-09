namespace Data.Structures.Account
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Activate { get; set; }
        public int AccessLevel { get; set; }
        public string LastIp { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public string DeletePlayerKey { get; set; }
    }
}
