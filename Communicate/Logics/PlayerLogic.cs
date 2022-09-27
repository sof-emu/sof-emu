using Data.Interfaces;
using Data.Models.Account;
using Data.Models.Npc;
using Data.Models.Player;
using Utility;

namespace Communicate.Logics
{
    public class PlayerLogic : Global
    {
        public static async void DeletePlayer(ISession session, int index, string password)
        {
            var result = await ApiService
                .SendDeletePlayer(index, password);

            // todo send packet delete response
        }

        public static void EnterWorld(ISession session, int playerIndex)
        {
            Player player = session
                .GetPlayer(playerIndex);

            session.SetSelectPlayer(player);

            MapService
                .EnterWorld(player);

            PlayerService
                .EnterWorld(player);
        }

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

        public static void PlayerMoved(Player player, float x1, float y1, float z1, float x2, float y2, float z2, float distance, int target)
        {
            Log.Debug($"PlayerMoved: {x1}, {y1}, {z1},{x2}, {y2}, {z2}, {distance}, {target}");
            PlayerService.PlayerMoved(player, x1, y1, z1, x2, y2, z2, distance, target);
            FeedbackService.PlayerMoved(player, x1, y1, z1, x2, y2, z2, distance, target);

            //PartyService.SendMemberPositionToPartyMembers(player);
        }

        public static void SelectNpc(ISession session, int statisticId)
        {
            Npc npc = session
                .GetSelectedPlayer()
                .GetMap()
                .GetNpc(statisticId);

            FeedbackService
                .SelectNpc(session, npc);
        }
    }
}
