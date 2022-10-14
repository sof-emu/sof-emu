using System;
using System.Collections.Generic;
using Utility;

namespace Data.Structures.World
{
    public class MapInstance : Statistical
    {
        public int MapId;

        public List<Player.Player> Players = new List<Player.Player>();
        public List<Npc.Npc> Npcs = new List<Npc.Npc>();
        public List<Item> Items = new List<Item>();

        public object CreaturesLock = new object();

        public virtual void OnMove(Player.Player player)
        {

        }

        public virtual void OnNpcKill(Player.Player killer, Npc.Npc killed)
        {

        }

        public virtual void Release()
        {
            try
            {
                for (int i = 0; i < Npcs.Count; i++)
                    Npcs[i].Release();

                Npcs.Clear();
            }
            catch (Exception ex)
            {
                Log.WarnException("MapInstance: Dispose", ex);
            }

            try
            {
                for (int i = 0; i < Items.Count; i++)
                    Items[i].Release();

                Items.Clear();
            }
            catch (Exception ex)
            {
                Log.WarnException("MapInstance: Dispose", ex);
            }
        }
    }
}
