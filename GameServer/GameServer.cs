using Communicate;
using Communicate.Logics;
using GameServer.Configs;
using GameServer.Database;
using GameServer.Networks;
using GameServer.Services;
using System;
using System.Diagnostics;
using System.Threading;
using Utility;

namespace GameServer
{
    internal class GameServer : Global
    {
        public static Config Config;

        public static Server Server;

        public static DatabaseFactory DBFactory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "SOF-Emu GameServer";
            Console.CancelKeyPress += CancelEventHandler;

            try
            {
                RunServer();
            }
            catch (Exception ex)
            {
                Log.FatalException("Can't start server!", ex);
                return;
            }

            MainLoop();

            StopServer();

            Process.GetCurrentProcess().WaitForExit();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RunServer()
        {
            Stopwatch sw = Stopwatch.StartNew();
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;

            Config = new Config();
            OpCodes.Init();
            DBFactory = new DatabaseFactory();

            // Services
            AccountService = new AccountService();
            ApiService = new ApiService();
            FeedbackService = new FeedbackService();
            MapService = new MapService();
            NpcService = new NpcService();
            PlayerService = new PlayerService();
            StatsService = new StatsService();
            VisibleService = new VisibleService();

            GlobalLogic.ServerStart();
            Console.WriteLine("\n-------------------------------------------\n");

            Server = new Server();

            sw.Stop();
            Thread.Sleep(100);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("           Server start in {0}", (sw.ElapsedMilliseconds / 1000.0).ToString("0.00s"));
            Console.WriteLine("-------------------------------------------");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void StopServer()
        {
            // todo
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected static void UnhandledException(Object sender, UnhandledExceptionEventArgs args)
        {
            Log.FatalException("UnhandledException", (Exception)args.ExceptionObject);

            while (true)
                Thread.Sleep(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected static void CancelEventHandler(object sender, ConsoleCancelEventArgs args)
        {
            while (true)
                Thread.Sleep(1);
        }
    }
}
