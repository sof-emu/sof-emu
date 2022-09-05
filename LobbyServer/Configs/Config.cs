using Nini.Config;

namespace LobbyServer.Configs
{
    public static class Config
    {
        private static IConfigSource source = new IniConfigSource("Configs/config.ini");

        public static string GetString(string ns, string name) => source.Configs[ns].GetString(name);

        public static int GetInt(string ns, string name) => source.Configs[ns].GetInt(name);

        public static long GetLong(string ns, string name) => source.Configs[ns].GetLong(name);

        public static bool GetBoolean(string ns, string name) => source.Configs[ns].GetBoolean(name);

        public static double GetDouble(string ns, string name) => source.Configs[ns].GetDouble(name);

        public static float GetFloat(string ns, string name) => source.Configs[ns].GetFloat(name);
    }
}
