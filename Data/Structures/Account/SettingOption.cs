using System.Collections;
using System.Runtime.CompilerServices;

namespace Data.Structures.Account
{
    public class SettingOption
    {
        public int Party { get; set; }
        public int Trade { get; set; }
        public int Whisper { get; set; }
        public int Costume { get; set; }
        public int Weapon { get; set; }
        public int PetExp { get; set; }
        public int Fame { get; set; }
        public int Hair { get; set; }
        public int Confestion { get; set; } // note
        public int Search { get; set; }
        public int FancyWeapon { get; set; }
        public int HonorRankEffect { get; set; }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetSettings(SettingOption Setting)
        {
            int flags = 0;
            if (Setting.Hair == 1)
            {
                SetFlags(ref flags, 7, true);
            }
            if (Setting.Costume == 1)
            {
                SetFlags(ref flags, 4, true);
                return flags;
            }
            SetFlags(ref flags, 6, true);
            return flags;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetFlags(ref int Flags, int ItemFlag, bool value)
        {
            int[] values = new int[] { Flags };
            BitArray array = new BitArray(values);
            array.Set(ItemFlag, value);
            Flags = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array.Get(i))
                {
                    Flags |= ((int)1) << i;
                }
            }
        }
    }
}
