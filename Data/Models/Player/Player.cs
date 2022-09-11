using Data.Interfaces;
using Data.Models.Account;
using Data.Models.World;

namespace Data.Models.Player
{
    public class Player : Creature.Creature, IPlayer
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }
        public int Level { get; set; }
        public long Exp { get; set; }
        public bool Online { get; set; }
        public int Job { get; set; }
        public int JobLevel { get; set; }
        public Position Position { get; set; }
        public long Money { get; set; }
        public int Force { get; set; }
        public string HairColor { get; set; }
        public int Face { get; set; }
        public int Voice { get; set; }
        public int Gender { get; set; }
        public int Title { get; set; }

        private AccountData Account;
        private ISession Session;
        private PlayerSetting Setting;

        public Player()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acc"></param>
        public void SetAccount(AccountData acc)
        {
            Account = acc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AccountData GetAccount()
        {
            return Account;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sess"></param>
        public void SetSession(ISession sess)
        {
            Session = sess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ISession GetSession()
        {
            return Session;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setting"></param>
        public void SetSetting(PlayerSetting setting)
        {
            Setting = setting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PlayerSetting GetSetting()
        {
            return Setting;
        }
    }
}
