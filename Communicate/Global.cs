using Communicate.Interfaces;
using Data.Interfaces.Database;
using System;
using System.Threading;
using Utility;

namespace Communicate
{
    public class Global
    {
        public static double ServerTime = 10000;

        // Services
        public static IAccountService AccountService;
        public static IApiService ApiService;
        public static IAuthService AuthService;
        public static IFeedbackService FeedbackService;
        public static IMapService MapService;
        public static INpcService NpcService;
        public static IPlayerService PlayerService;
        public static IVisibleService VisibleService;

        // Engines

        // Database Repositories
        public static IAccountRepository AccountRepository;
        public static IPlayerRepository PlayerRepository;
        public static IInventoryRepository InventoryRepository;

        //
        protected static bool ServerIsWork = true;
        protected static Thread MapServiceLoopThread;

        public static void InitMainLoop()
        {
            MapServiceLoopThread = new Thread(MapServiceLoop);
            MapServiceLoopThread.Start();
        }

        protected static void MainLoop()
        {
            
            while (ServerIsWork)
            {
                try
                {
                    ServerTime = Funcs.GetServerTime(ServerTime);

                    //Services:
                    AccountService.Action();
                    ApiService.Action();
                    FeedbackService.Action();
                    MapService.Action();
                    NpcService.Action();
                    PlayerService.Action();

                    //Engines:

                    //Others:
                    DelayedAction.CheckActions();
                }
                catch (Exception ex)
                {
                    Log.ErrorException("MainLoop:", ex);
                }

                Thread.Sleep(10);
            }
        }

        protected static void MapServiceLoop()
        {
            while (true)
            {
                try
                {
                    MapService.Action();
                }
                catch (Exception ex)
                {
                    Log.ErrorException("MapServiceLoop:", ex);
                }

                Thread.Sleep(1);
            }
        }
    }
}
