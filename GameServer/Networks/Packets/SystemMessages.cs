using Data.Enums;
using GameServer.Networks.Packets.Response;
using Nini.Config;

namespace GameServer.Networks.Packets
{
    public class SystemMessages
    {
        private static IConfig conf = GameServer.Config["system_message"].Configs["system_message"];

        public static ResponseChatMessage EnterGameMessage = new ResponseChatMessage(conf.GetString("EnterWorld"), ChatType.Announce);
        public static ResponseChatMessage InventoryIsFull = new ResponseChatMessage(conf.GetString("InventoryIsFull"), ChatType.UNK1);
        public static ResponseChatMessage YouCantPickUpItem = new ResponseChatMessage(conf.GetString("CantPickItem"), ChatType.UNK1);
    }
}
