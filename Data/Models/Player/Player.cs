using Data.Interfaces;
using Data.Models.Account;
using Data.Models.World;

namespace Data.Models.Player
{
    public class Player : Creature.Creature
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
        public int Title { get; set; }

        private AccountData Account;
        private PlayerData playerData;
        private ISession Session;

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
        /// <param name="data"></param>
        public void SetPlayerData(PlayerData data)
        {
            playerData = data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PlayerData GetPlayerData()
        {
            return playerData;
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
    }
}
