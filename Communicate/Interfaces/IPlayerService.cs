using Data.Enums;
using Data.Interfaces;
using Data.Structures.Account;
using Data.Structures.Player;
using System.Collections.Generic;

namespace Communicate.Interfaces
{
    public interface IPlayerService : IComponent
    {
        void CheckNameExist(ISession session, string name);
        Player CreatePlayer(ISession session, string name, PlayerClass playerClass, string hairColor, int voice, int gender);
        //void EnterWorld(Player player);
        void InitPlayer(Player player);
        List<Player> OnAuthorized(Account account);
        void OnUpdateSetting(ISession session);
        void PlayerMoved(Player player, float x1, float y1, float z1, float x2, float y2, float z2, float distance, int tagert);
        void SendPlayerLists(ISession session);
    }
}
