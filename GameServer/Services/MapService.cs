using Communicate.Interfaces;
using Communicate.Logics;
using Data.Structures;
using Data.Structures.Creature;
using Data.Structures.Geometry;
using Data.Structures.Npc;
using Data.Structures.Player;
using Data.Structures.Template.Item;
using Data.Structures.Template.World;
using Data.Structures.World;
using GameServer.Extension;
using GameServer.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Utility;
using Utility.Extension;

namespace GameServer.Services
{
    public class MapService : IMapService
    {
        protected Dictionary<int, MapInstance> Maps = new Dictionary<int, MapInstance>();
        public static object MapLock = new object();

        public static Dictionary<int, Type> Dungeons = new Dictionary<int, Type>();

        public void Action()
        {
            try
            {
                foreach (var map in Maps.Values)
                {
                    for(int i = 0; i < map.Npcs.Count; i++)
                    {
                        try
                        {
                            map.Npcs[i].Ai.Action();
                        }
                        catch
                        {

                        }

                        if ((i & 1023) == 0) // 2^N - 1
                            Thread.Sleep(1);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.ErrorException("MapService.Action: ", ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            // todo: Start Map Instance from map data templater
            // load map data from json
            // load spawn templater
            var list = Data.Data.MapTemplates.Values.ToList();
            list.ForEach(map =>
            {
                MapInstance mapInstance = new MapInstance();

                if (Data.Data.SpawnTemplates.ContainsKey(map.Id))
                    Data.Data.SpawnTemplates[map.Id].ForEach(spawn => 
                        SpawnRxjhObject(CreateNpc(spawn, map.Id), mapInstance));

                Maps.Add(map.Id, mapInstance);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void PlayerEnterWorld(Player player)
        {
            if (!Maps.ContainsKey(player.Position.MapId))
                lock (MapLock)
                    Maps.Add(player.Position.MapId, new MapInstance());

            MapInstance instance = Maps[player.Position.MapId];

            SpawnRxjhObject(player, instance);

            if (player.Visible != null)
            {
                player.Visible.Stop();
                player.Visible.Release();
                player.Visible = null;
            }

            player.Visible = new Visible { Player = player };
            player.Visible.Start();

            //map.GetPlayers()
            //    .ForEach(people => Global.VisibleService.Broadcast(player, new ResponsePlayerInfo(people)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void PlayerLeaveWorld(Player player)
        {
            if (player.Instance != null)
            {
                DespawnRxjhObject(player);

                player.Instance = null;

                player.Visible.Stop();
                player.Visible.Release();
                player.Visible = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="instance"></param>
        public void SpawnRxjhObject(RxjhObject obj, MapInstance instance)
        {
            var creature = obj as Creature;
            if(creature != null)
            {
                lock(instance.CreaturesLock)
                {
                    if (obj is Npc)
                        instance.Npcs.Add((Npc)obj);
                    else if (obj is Player)
                        instance.Players.Add((Player)obj);
                    else if (obj is Item)
                        instance.Items.Add((Item)obj);
                }

                creature.Instance = instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void DespawnRxjhObject(RxjhObject obj)
        {
            var creature = obj as Creature;
            if (creature != null)
            {
                lock (creature.Instance.CreaturesLock)
                {
                    if (creature is Npc)
                    {
                        creature.Instance.Npcs.Remove((Npc)obj);
                        creature.VisiblePlayers.Each(player =>
                        {
                            player.VisibleNpcs.Remove((Npc)obj);
                            PlayerLogic.OutOfVision(player, creature);
                        });
                    }
                    else if (creature is Player)
                    {
                        creature.Instance.Players.Remove((Player)obj);
                        creature.VisiblePlayers.Each(player =>
                        {
                            player.VisiblePlayers.Remove((Player)obj);
                            PlayerLogic.OutOfVision(player, creature);
                        });
                    }
                    else if (creature is Item)
                    {
                        creature.Instance.Items.Remove((Item)obj);
                        creature.VisiblePlayers.Each(player =>
                        {
                            player.VisibleItems.Remove((Item)obj);
                            PlayerLogic.OutOfVision(player, creature);
                        });
                    }
                }

                if (!(creature is Player))
                    creature.Release();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spawnTemplate"></param>
        /// <param name="mapId"></param>
        /// <returns></returns>
        public static Npc CreateNpc(SpawnTemplate spawnTemplate, int mapId)
        {
            var npc = new Npc
            {
                NpcId = spawnTemplate.NpcId,
                SpawnTemplate = spawnTemplate,
                NpcTemplate = Data.Data.NpcTemplates[spawnTemplate.NpcId],

                Position = new WorldPosition
                {
                    MapId = mapId,
                    X = spawnTemplate.X,
                    Y = spawnTemplate.Y,
                    Z = spawnTemplate.Z
                },
            };

            npc.BindPoint = npc.Position.Clone();

            npc.GameStats = CreatureLogic.InitGameStats(npc);
            CreatureLogic.UpdateCreatureStats(npc);

            AiLogic.InitAi(npc);

            return npc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="npc"></param>
        /// <param name="player"></param>
        public void CreateDrop(Npc npc, Player player)
        {
            /*if (Funcs.IsLuck(98))
            {
                var money = (int)(10 * npc.NpcTemplate.Exp / Funcs.Random().Next(20, 60));
                var item = new Item
                {
                    Owner = player,
                    Npc = npc,

                    ItemId = 2000000000,
                    Count = money,
                    Position = Geom.RandomCirclePosition(npc.Position, Funcs.Random().Next(5, 10)),
                    Instance = player.Instance,
                };

                //if (Custom.MONEY_DROP_STYLE == 1)
                //{
                    player.Inventory.Money += money;
                    //new SpItemPickupMsg(ItemPickUp.GotMoney, item).Send(player);
                //}
                //else
                //{
                //    player.Instance.AddDrop(item);
                //}
            }*/

            //if (Funcs.IsLuck(30))
            //    return;

            if (!Data.Data.DropItemTemplates.ContainsKey(npc.NpcTemplate.Id))
                return;

            List<DropItemTemplate> items = Data.Data.DropItemTemplates[npc.NpcTemplate.Id];

            if (items == null)
                return;

            int count = 0;
            int rate = Funcs.Random().Next(0, 2500);

            if (rate < 10)
                count = 6;
            else if (rate < 30)
                count = 5;
            else if (rate < 90)
                count = 4;
            else if (rate < 270)
                count = 3;
            else if (rate < 600)
                count = 2;
            else if (rate < 1800)
                count = 1;

            if (items.Count < count)
                count = items.Count;

            for (int i = 0; i < count; i++)
            {
                DropItemTemplate drop = items[Funcs.Random().Next(0, items.Count)];

                if (!Data.Data.ItemTemplates.ContainsKey(drop.ItemId))
                    continue;

                if (!Funcs.IsLuck(drop.Chance))
                    continue;

                player.Instance.AddDrop(
                    new Item
                    {
                        Owner = player,
                        Npc = npc,

                        ItemId = drop.ItemId,
                        Count = drop.Quanty,
                        Position = Geom.RandomCirclePosition(npc.Position, Funcs.Random().Next(2, 4)),
                        Instance = player.Instance,
                    });
            }
        }

        public bool IsDungeon(int mapId)
        {
            return Dungeons.ContainsKey(mapId);
        }
    }
}
