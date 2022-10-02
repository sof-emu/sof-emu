using Data.Enums;
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
        public Position LastPostion { get; set; }
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
        private Inventory Inventory;
        private PlayerState State;

        public Player()
        {
            LastPostion = new Position()
            {
                X = 0,
                Y = 0,
                Z = 0,
                MapId = 0
            };

            State = PlayerState.Idle;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inven"></param>
        public void SetInventory(Inventory inven)
        {
            Inventory = inven;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Inventory GetInventory()
        {
            return Inventory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void SetState(PlayerState state)
        {
            State = state;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PlayerState GetState()
        {
            return State;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        public void Moved(float x1, float y1, float z1, float x2, float y2, float z2)
        {
            Position.X = x1;
            Position.Y = y1;
            Position.Z = z1;

            LastPostion.X = x2;
            LastPostion.Y = y2;
            LastPostion.Z = z2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Position GetPosition()
        {
            return Position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        public override void SetPosition(Position pos)
        {
            base.SetPosition(pos);
            Position = pos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Position GetLastPosition()
        {
            return LastPostion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        public void SetLastPostion(Position pos)
        {
            LastPostion = pos;
        }
    }
}
