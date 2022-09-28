using Data.Models.Creature;
using Data.Models.Template.Creatures;
using Data.Models.Template.Item;
using Data.Models.Template.World;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Utility;

namespace Data
{
    public class Data
    {
        public static string DataPath = Path.GetFullPath("Data");

        public static Dictionary<long, MapTemplate> MapTemplates;
        public static Dictionary<long, ItemTemplate> ItemTemplates;
        public static Dictionary<int, GameStats> StatsTemplates;
        public static Dictionary<int, NpcTemplate> NpcTemplates;
        public static Dictionary<int, List<SpawnTemplate>> SpawnTemplates;
        public static Dictionary<int, List<ShopItemTemplate>> ShopItemsTemplates;

        protected delegate int Loader();
        protected static List<Loader> Loaders = new List<Loader>
                                                    {
                                                        LoadMapTemplates,
                                                        //LoadPlayerExperience,
                                                        LoadBaseStats,
                                                        LoadItemTemplates,
                                                        //LoadBindPoints,
                                                        LoadNpcTemplates,
                                                        LoadSpawnTemplates,
                                                        LoadShopItemTemplates,
                                                        //LoadQuests,
                                                        //LoadSkills,
                                                        //LoadAbilities,
                                                        //LoadAbnormalities,
                                                        //LoadDrop,
                                                        //LoadTeleports,
                                                        //CalculateNpcExperience,
                                                    };

        /// <summary>
        /// 
        /// </summary>
        public static void LoadAll()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("           Start loading datas");
            Console.WriteLine("-------------------------------------------");
            Parallel.For(0, Loaders.Count, i => LoadTask(Loaders[i]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loader"></param>
        private static void LoadTask(Loader loader)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int readed = loader.Invoke();
            stopwatch.Stop();

            Log.Info("Data: {0,-26} {1,7} values in {2}s"
                , loader.Method.Name
                , readed
                , (stopwatch.ElapsedMilliseconds / 1000.0).ToString("0.00"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int LoadMapTemplates()
        {
            MapTemplates = new Dictionary<long, MapTemplate>();

            string jsonStr = File.ReadAllText(Path.Combine(DataPath, "maps.json"));
            List<MapTemplate> list = JsonConvert.DeserializeObject<List<MapTemplate>>(jsonStr);

            list.ForEach(item =>
            {
                if (!MapTemplates.ContainsKey(item.Id))
                    MapTemplates.Add(item.Id, item);
            });

            return MapTemplates.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int LoadBaseStats()
        {
            StatsTemplates = new Dictionary<int, GameStats>();

            string jsonStr = File.ReadAllText(Path.Combine(DataPath, "stats.json"));
            List<GameStats> list = JsonConvert.DeserializeObject<List<GameStats>>(jsonStr);

            list.ForEach(item =>
            {
                if (!StatsTemplates.ContainsKey(item.Job))
                    StatsTemplates.Add(item.Job, item);
            });

            return StatsTemplates.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int LoadItemTemplates()
        {
            ItemTemplates = new Dictionary<long, ItemTemplate>();

            string jsonStr = File.ReadAllText(Path.Combine(DataPath, "items.json"));
            List<ItemTemplate> list = JsonConvert.DeserializeObject<List<ItemTemplate>>(jsonStr);

            list.ForEach(item =>
            {
                if(!ItemTemplates.ContainsKey(item.Id))
                    ItemTemplates.Add(item.Id, item);
            });

            return ItemTemplates.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int LoadNpcTemplates()
        {
            NpcTemplates = new Dictionary<int, NpcTemplate>();

            string jsonStr = File.ReadAllText(Path.Combine(DataPath, "npcs.json"));
            List<NpcTemplate> list = JsonConvert.DeserializeObject<List<NpcTemplate>>(jsonStr);

            list.ForEach(npc =>
            {
                if (!NpcTemplates.ContainsKey(npc.Id))
                    NpcTemplates.Add(npc.Id, npc);
            });

            return NpcTemplates.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int LoadSpawnTemplates()
        {
            SpawnTemplates = new Dictionary<int, List<SpawnTemplate>>();
            string spawnDataPath = Path.Combine(DataPath, "spawns");

            string[] files = Directory.GetFiles(spawnDataPath);
            int length = 0;

            foreach(string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                int mapId = int.Parse(fileInfo.Name.Replace(".json", ""));
                string jsonStr = File.ReadAllText(file);
                List<SpawnTemplate> list = JsonConvert.DeserializeObject<List<SpawnTemplate>>(jsonStr);

                List<SpawnTemplate> spawns = new List<SpawnTemplate>();
                list.ForEach(spawn =>
                {
                    spawns.Add(spawn);
                    length++;
                });

                if (!SpawnTemplates.ContainsKey(mapId))
                    SpawnTemplates.Add(mapId, spawns);
            }

            return length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int LoadShopItemTemplates()
        {
            ShopItemsTemplates = new Dictionary<int, List<ShopItemTemplate>>();
            string shopDataPath = Path.Combine(DataPath, "shops");

            string[] files = Directory.GetFiles(shopDataPath);
            int length = 0;

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                int shopId = int.Parse(fileInfo.Name.Replace("SHOP_", "").Replace(".json", ""));
                string jsonStr = File.ReadAllText(file);
                List<ShopItemTemplate> list = JsonConvert.DeserializeObject<List<ShopItemTemplate>>(jsonStr);

                List<ShopItemTemplate> items = new List<ShopItemTemplate>();
                list.ForEach(item =>
                {
                    items.Add(item);
                    length++;
                });

                if (!ShopItemsTemplates.ContainsKey(shopId))
                    ShopItemsTemplates.Add(shopId, items);
            }

            return length;
        }
    }
}
