using Data.Interfaces;
using System.Collections.Generic;

namespace Communicate.Logics
{
    public class GlobalLogic : Global
    {
        protected static Dictionary<int, int> hackSpeedDetect = new Dictionary<int, int>();

        /// <summary>
        /// 
        /// </summary>
        public static void ServerStart()
        {
            Data.Data.LoadAll();

            MapService.Init();

            InitMainLoop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public static void ClientPing(ISession session)
        {
            session.Ping();

            // todo
            FeedbackService
                .SendServerTime(session);
        }
    }
}
