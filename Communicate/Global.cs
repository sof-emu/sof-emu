using Communicate.Interfaces;
using Data.Interfaces;
using System.Threading;
using System;
using Utility;

namespace Communicate
{
    public class Global
    {
        // Services
        public static IApiService ApiService;
        public static IAuthService AuthService;
        public static IFeedbackService FeedbackService;
        public static IPlayerService PlayerService;

        // Engines


        protected static bool ServerIsWork = true;

        protected static void MainLoop()
        {
            while (ServerIsWork)
            {
                try
                {
                    //Services:

                    FeedbackService.Action();
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
    }
}
