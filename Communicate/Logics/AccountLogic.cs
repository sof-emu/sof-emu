using Data.Interfaces;
using Data.Structures.Account;
using System;

namespace Communicate.Logics
{
    public class AccountLogic : Global
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="username"></param>
        /// <param name="ip"></param>
        /// <param name="mac"></param>
        public static void TryAuthorize(ISession session, string username, string ip, string mac)
        {
            AccountService.Authorized(session, username);
            FeedbackService.OnAuthorized(session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="setting"></param>
        public static void OptionSetting(ISession session, SettingOption setting)
        {
            AccountService
                .SetSettingOption(session, setting);

            // todo
            // send broadcast player data
            PlayerService
                .OnUpdateSetting(session);
            // send broadcast equipment data & effect
            // send broadcast skill and status
            // send broadcast Update Qigong
            // send update world time
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        public static void GetPlayerList(ISession session)
        {
            FeedbackService.SendPlayerList(session);
        }
    }
}
