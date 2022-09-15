using Data.Models.Template.Item;
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

        public static Dictionary<long, ItemTemplate> ItemTemplates = new Dictionary<long, ItemTemplate>();

        protected delegate int Loader();

        protected static List<Loader> Loaders = new List<Loader>
                                                    {
                                                        //LoadMapTemplates,
                                                        //LoadPlayerExperience,
                                                        //LoadBaseStats,
                                                        LoadItemTemplates,
                                                        //LoadSpawns,
                                                        //LoadBindPoints,
                                                        //LoadNpcTemplates,
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
        public static int LoadItemTemplates()
        {
            ItemTemplates = new Dictionary<long, ItemTemplate>();

            string[] files = Directory.GetFiles(Path.Combine(DataPath, "Items"));
            foreach (string file in files)
            {
                string jsonStr = File.ReadAllText(Path.Combine(DataPath + "/Items/", file));
                ItemTemplate itemTemplate = JsonConvert.DeserializeObject<ItemTemplate>(jsonStr);
                ItemTemplates.Add(itemTemplate.Id, itemTemplate);
            }

            return ItemTemplates.Count;
        }
    }
}
