using Data.Interfaces;
using Data.Models.Account;
using Data.Models.Player;
using System;

namespace Communicate.Logics
{
    public class PlayerLogic : Global
    {
        public static void EnterWorld(ISession session, int playerIndex)
        {
            Player player = session
                .GetPlayer(playerIndex);

            session.SetSelectPlayer(player);

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

        public static void PlayerMoved(Player player, float x1, float y1, float z1, float x2, float y2, float z2, float distance, int tagert)
        {
            PlayerService.PlayerMoved(player, x1, y1, z1, x2, y2, z2, distance, tagert);
            FeedbackService.PlayerMoved(player, x1, y1, z1, x2, y2, z2, distance, tagert);

            //PartyService.SendMemberPositionToPartyMembers(player);
        }
    }
}
