using LobbyServer.Database;
using LobbyServer.Networks;
using System;
using System.Diagnostics;
using System.Threading;

namespace LobbyServer
{
    internal class Program
    {
        public static DBOManager DBOManager;

        static void Main(string[] args)
        {
            Console.Title = "SOF-Emu LobbyServer";

            Stopwatch sw = Stopwatch.StartNew();

            DBOManager = new DBOManager();

            // Services

            new Server()
                .BeginListening();

            sw.Stop();
            Thread.Sleep(100);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("           Server start in {0}", (sw.ElapsedMilliseconds / 1000.0).ToString("0.00s"));
            Console.WriteLine("-------------------------------------------");

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}
