using GameServer.Configs;
using GameServer.Networks;
using GameServer.Services;
using System;
using System.Diagnostics;
using System.Threading;

namespace GameServer
{
    internal class Program
    {
        public static Config Config;

        public static Server Server;

        // Services
        public static ApiService ApiService;
        public static AuthService AuthService;

        static void Main(string[] args)
        {
            Console.Title = "SOF-Emu GameServer";

            Stopwatch sw = Stopwatch.StartNew();

            Config = new Config();
            
            // Services
            ApiService = new ApiService();
            AuthService = new AuthService();


            Server = new Server();

            sw.Stop();
            Thread.Sleep(100);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("           Server start in {0}", (sw.ElapsedMilliseconds / 1000.0).ToString("0.00s"));
            Console.WriteLine("-------------------------------------------");

            Process.GetCurrentProcess().WaitForExit();

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}
