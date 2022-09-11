using Data.Interfaces;

namespace Data.Models.Account
{
    public class AccountData
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public bool Activate { get; set; }

        public int AccessLevel { get; set; }

        public string LastIp { get; set; }

        public string Email { get; set; }

        public float Balance { get; set; }
    }
}
