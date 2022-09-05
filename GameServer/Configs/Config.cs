using Nini.Config;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer.Configs
{
    public class Config : Dictionary<string, IniConfigSource> 
    {
        public Config()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Configs";
            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                if(file.EndsWith(".ini"))
                {
                    string name = Path.GetFileName(file).Replace(".ini", "");
                    var source = new IniConfigSource(file);
                    Add(name, source);
                }
            }
        }
    }
}
