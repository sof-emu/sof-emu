using GameServer.Configs;
using GameServer.Networks;
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

        static void Main(string[] args)
        {
            Console.Title = "SOF-Emu GameServer";

            Stopwatch sw = Stopwatch.StartNew();

            Config = new Config();

            Server = new Server();

            // Services

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
