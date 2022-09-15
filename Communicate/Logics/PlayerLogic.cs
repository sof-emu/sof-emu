using Data.Interfaces;
using Data.Models.Account;
using Data.Models.Player;

namespace Communicate.Logics
{
    public class PlayerLogic : Global
    {
        public static void EnterWorld(ISession session, int playerIndex)
        {
            Player player = session
                .GetPlayer(playerIndex);

            PlayerService
                .EnterWorld(player);

            MapService
                .EnterWorld(player);
        }

        public static void OptionSetting(ISession session, SettingOption setting)
        {
            AccountService
                .SetSettingOption(session, setting);

            // todo
            // send broadcast player data
            //PlayerService
            //    .OnUpdateSetting(session);
            // send broadcast equipment data & effect
            // send broadcast skill and status
            // send broadcast Update Qigong
            // send update world time
        }
    }
}
