using Communicate;
using Data.Structures.World;
using GameServer.Networks.Packets.Response;
using Utility;

namespace GameServer.Extension
{
    public static class MapInstanceExtension
    {
        public static void AddDrop(this MapInstance instance, Item item)
        {
            instance.Items.Add(item);

            new DelayedAction(() => instance.RemoveItem(item), 60000);
        }

        public static void RemoveItem(this MapInstance instance, Item item)
        {
            try
            {
                instance.Items.Remove(item);
                Global.VisibleService.Send(item, new ResponseDropRemove(item));
                item.Release();
            }
            catch
            {
                //Already removed
            }
        }
    }
}
