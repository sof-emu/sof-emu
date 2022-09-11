using Communicate;
using GameServer.Configs;
using GameServer.Networks;
using GameServer.Services;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Utility;

namespace GameServer
{
    internal class GameServer : Global
    {
        public static Config Config;

        public static Server Server;

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

            Process.GetCurrentProcess().Kill();
        }

        private static void RunServer()
        {
            Stopwatch sw = Stopwatch.StartNew();
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;

            Config = new Config();
            OpCodes.Init();

            // Services
            ApiService = new ApiService();
            AuthService = new AuthService();
            FeedbackService = new FeedbackService();
            PlayerService = new PlayerService();


            Server = new Server();

            sw.Stop();
            Thread.Sleep(100);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("           Server start in {0}", (sw.ElapsedMilliseconds / 1000.0).ToString("0.00s"));
            Console.WriteLine("-------------------------------------------");
        }

        private static void StopServer()
        {
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
