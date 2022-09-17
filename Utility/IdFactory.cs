using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Utility
{
    public class IDFactory
    {
        private List<int> Ids = new List<int>();
        private List<int> StaticIds = new List<int>();

        private int lastId = 100;

        private int StaticLastId = 10000;

        public IDFactory()
        {
            Ids.Add(lastId);
            StaticIds.Add(StaticLastId);

            Log.Debug("Initialized IDFactory");
        }

        public int GetNext()
        {
            lock (Ids)
            {
                Interlocked.Increment(ref lastId);

                while (!Ids.Contains<int>(lastId))
                {
                    if (Ids.Contains<int>(lastId))
                    {
                        Interlocked.Increment(ref lastId);
                    }
                    else
                    {
                        Ids.Add(lastId);
                        break;
                    }
                }
            }

            return lastId;
        }

        public int GetNextStatic()
        {
            lock (StaticIds)
            {
                Interlocked.Increment(ref StaticLastId);

                while (!StaticIds.Contains<int>(StaticLastId))
                {
                    if (StaticIds.Contains<int>(StaticLastId))
                    {
                        Interlocked.Increment(ref StaticLastId);
                    }
                    else
                    {
                        StaticIds.Add(StaticLastId);
                        break;
                    }
                }
            }

            return StaticLastId;
        }

        public void Release(int val)
        {
            lock (Ids)
            {
                if (Ids.Contains(val))
                {
                    Ids.Remove(val);
                    lastId = val;
                }
            }
        }
    }
}
