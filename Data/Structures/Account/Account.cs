using Data.Interfaces;
using System.Collections.Generic;

namespace Data.Structures.Account
{
    public class Account
    {
        public ISession Session;
        public SettingOption SettingOption;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Activate { get; set; }
        public int AccessLevel { get; set; }
        public string LastIp { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public string DeletePlayerKey { get; set; }

        public List<Player.Player> Players = new List<Player.Player>();
        public long lastOnlineUtc;
    }
}
