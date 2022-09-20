using Data.Interfaces;
using System;
using System.Collections.Generic;

namespace Communicate.Logics
{
    public class GlobalLogic : Global
    {
        protected static Dictionary<int, int> hackSpeedDetect = new Dictionary<int, int>();

        public static void ServerStart()
        {
            Data.Data.LoadAll();

            MapService.Init();

            InitMainLoop();
        }

        public static void ClientPing(ISession session)
        {
            if ((int)DateTime.Now.Subtract(session.GetLastPing()).TotalMilliseconds < 10000)
            {
                int times = 0;
                hackSpeedDetect.TryGetValue(session.SessionId, out times);
                times++;
                if(times > 3)
                {
                    // todo send system hint
                    // The game runs abnormally
                    // disconnect client
                }
            }
            session.SetLastPing(DateTime.Now);
        }
    }
}
