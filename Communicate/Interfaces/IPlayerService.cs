using Data.Enums;
using Data.Interfaces;
using Data.Models.Player;

namespace Communicate.Interfaces
{
    public interface IPlayerService : IComponent
    {
        void CheckNameExist(ISession session, string name);
        void CreatePlayer(ISession session, string name, PlayerClass playerClass, string hairColor, int voice, int gender);
        void SendPlayerLists(ISession session);
        void SetPlayerSetting(ISession session, PlayerSetting setting);
    }
}
