using Communicate;
using Communicate.Logics;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.World;
using Utility.Extension;

namespace GameServer.Structures
{
    public class Visible : IVisible
    {
        protected const int VisibleDistance = 200;

        public Player Player { get; set; }

        protected bool IsActive = false;

        protected object UpdateLock = new object();

        public void Start()
        {
            lock (UpdateLock)
            {
                if (IsActive)
                    return;

                IsActive = true;
            }
        }

        public void Stop()
        {
            lock (UpdateLock)
                IsActive = false;

            ClearVisibleObjets();
        }

        public void Release()
        {
            ClearVisibleObjets();
            Player = null;
        }

        public static bool IsVisible(Player player, Creature creature)
        {
            if (creature is Player && !Global.PlayerService.IsPlayerOnline((Player)creature))
                return false;

            if (creature == null)
                return false;

            if (!(creature is Item) && creature.LifeStats.IsDead())
                return false;

            if (player.Position.DistanceTo(creature.Position) > VisibleDistance)
                return false;

            return true;
        }

        public void Update()
        {
            if (!IsActive)
                return;

            lock (UpdateLock)
            {
                //Check for offline
                lock (Player.Instance.CreaturesLock)
                {
                    Player.VisiblePlayers.Each(CheckPlayer);

                    Player.Instance.Players.Each(CheckPlayer);
                    Player.Instance.Npcs.Each(CheckNpc);
                    Player.Instance.Items.Each(CheckItem);
                }
            }
        }

        private void CheckPlayer(Player otherPlayer)
        {
            if (Player == otherPlayer)
                return;

            if (IsVisible(Player, otherPlayer))
            {
                if (!Player.VisiblePlayers.Contains(otherPlayer))
                {
                    Player.VisiblePlayers.Add(otherPlayer);
                    PlayerLogic.InTheVision(Player, otherPlayer);
                }
            }
            else
            {
                if (Player.VisiblePlayers.Contains(otherPlayer))
                {
                    Player.VisiblePlayers.Remove(otherPlayer);
                    PlayerLogic.OutOfVision(Player, otherPlayer);
                }
            }
        }

        private void CheckNpc(Npc npc)
        {
            if (IsVisible(Player, npc))
            {
                if (!Player.VisibleNpcs.Contains(npc))
                {
                    Player.VisibleNpcs.Add(npc);
                    npc.VisiblePlayers.Add(Player);
                    PlayerLogic.InTheVision(Player, npc);
                }
            }
            else
            {
                if (Player.VisibleNpcs.Contains(npc))
                {
                    Player.VisibleNpcs.Remove(npc);
                    npc.VisiblePlayers.Remove(Player);
                    PlayerLogic.OutOfVision(Player, npc);
                }
            }
        }

        private void CheckItem(Item item)
        {
            if (IsVisible(Player, item))
            {
                if (!Player.VisibleItems.Contains(item))
                {
                    Player.VisibleItems.Add(item);
                    item.VisiblePlayers.Add(Player);
                    PlayerLogic.InTheVision(Player, item);
                }
            }
            else
            {
                if (Player.VisibleItems.Contains(item))
                {
                    Player.VisibleItems.Remove(item);
                    if (item.VisiblePlayers != null)
                        item.VisiblePlayers.Remove(Player);
                    PlayerLogic.OutOfVision(Player, item);
                }
            }
        }

        private void ClearVisibleObjets()
        {
            lock (UpdateLock)
            {
                foreach (Npc npc in Player.VisibleNpcs)
                    if (npc.VisiblePlayers != null && npc.VisiblePlayers.Contains(Player))
                        npc.VisiblePlayers.Remove(Player);

                Player.VisibleNpcs.Clear();
                Player.VisiblePlayers.Clear();
                Player.VisibleItems.Clear();
            }
        }
    }
}
