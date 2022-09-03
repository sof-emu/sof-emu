using LobbyServer.Networks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LobbyServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SOF-Emu LobbyServer";

            Stopwatch sw = Stopwatch.StartNew();

            sw.Stop();
            new Server("0.0.0.0", 1300, 100)
                .BeginListening();

            Thread.Sleep(100);
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("           Server start in {0}", (sw.ElapsedMilliseconds / 1000.0).ToString("0.00s"));
            Console.WriteLine("-------------------------------------------");

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}
