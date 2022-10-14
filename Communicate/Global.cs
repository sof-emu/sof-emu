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
        public static IAiService AiService;
        public static IApiService ApiService;
        public static IControllerService ControllerService;
        public static IFeedbackService FeedbackService;
        public static IMapService MapService;
        public static INpcService NpcService;
        public static IObserverService ObserverService;
        public static IPlayerService PlayerService;
        public static IStatsService StatsService;
        public static IStorageService StorageService;
        public static IVisibleService VisibleService;

        // Engines
        public static ISkillEngine SkillEngine;

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
                    AiService.Action();
                    ApiService.Action();
                    ControllerService.Action();
                    FeedbackService.Action();
                    MapService.Action();
                    NpcService.Action();
                    ObserverService.Action();
                    PlayerService.Action();
                    StatsService.Action();
                    StorageService.Action();
                    VisibleService.Action();

                    //Engines:
                    SkillEngine.Action();

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
