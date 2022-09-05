using GameServer.Configs;
using System;
using System.Diagnostics;
using System.Linq;

namespace GameServer
{
    internal class Program
    {
        public static Config Config;
        static void Main(string[] args)
        {
            Config = new Config();

            //Console.WriteLine(Config["database"].Configs["database"].GetString("host"));

            Config.Where(i => i.Key.StartsWith("server")).ToList().ForEach(i => {
                Console.WriteLine(i.Value.Configs["server"].GetString("ip"));
            });

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}
