using Data.Enums;
using Data.Structures.Player;
using Data.Structures.SkillEngine;
using System.Collections.Generic;
using Utility;

namespace Data.Structures
{
    public class UidFactory
    {
        #region static

        protected static Dictionary<ObjectFamily, UidFactory> GlobalFactories = new Dictionary<ObjectFamily, UidFactory>();

        protected static object FactoriesLock = new object();

        public static UidFactory Factory(ObjectFamily family)
        {
            lock (FactoriesLock)
            {
                if (!GlobalFactories.ContainsKey(family))
                    GlobalFactories.Add(family, new UidFactory(family));
            }

            return GlobalFactories[family];
        }

        public static UidFactory Factory(object o)
        {
            return Factory(GetFamily(o));
        }

        public static ObjectFamily GetFamily(object o)
        {
            if (o is Attack)
                return ObjectFamily.Attack;

            if (o is Player.Player)
                return ObjectFamily.Player;

            if (o is Npc.Npc)
                return ObjectFamily.Npc;

            if (o is StorageItem)
                return ObjectFamily.InventoryItem;

            Log.Error("UidFactory: Unknown object type: {0}", o.GetType().Name);
            return ObjectFamily.System;
        }

        #endregion

        protected object Lock = new object();

        protected int NextUid = 10000;

        protected Queue<int> FreeUidList = new Queue<int>();

        protected Dictionary<int, Uid> RegisteredObjects = new Dictionary<int, Uid>();

        public UidFactory(ObjectFamily family)
        {
            if (family == ObjectFamily.Player)
                NextUid = 100;
        }

        public Uid FindObject(int uid)
        {
            lock (Lock)
            {
                return RegisteredObjects.ContainsKey(uid)
                           ? RegisteredObjects[uid]
                           : null;
            }
        }

        public int RegisterObject(Uid o)
        {
            lock (Lock)
            {
                int uid = FreeUidList.Count > 0
                              ? FreeUidList.Dequeue()
                              : NextUid++;

                RegisteredObjects.Add(uid, o);

                return uid;
            }
        }

        public void Release(Uid o, int uid)
        {
            if (uid == 0)
                return;

            lock (Lock)
            {
                RegisteredObjects.Remove(uid);
                FreeUidList.Enqueue(uid);
            }
        }
    }
}
