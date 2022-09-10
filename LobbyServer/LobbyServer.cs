using LobbyServer.Networks;
using LobbyServer.Services;
using System;
using System.Diagnostics;
using System.Threading;

namespace LobbyServer
{
    internal class LobbyServer
    {
        //public static DBOManager DBOManager;

        // Services
        public static ApiService ApiService;
        public static AuthService AuthService;
        public static FeedbackService BroadcastService;

        static void Main(string[] args)
        {
            Console.Title = "SOF-Emu LobbyServer";

            Stopwatch sw = Stopwatch.StartNew();

            //DBOManager = new DBOManager();

            // Services
            ApiService = new ApiService();
            AuthService = new AuthService();
            BroadcastService = new FeedbackService();

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
