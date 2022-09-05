using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.Scs.Server;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Utility;

namespace LobbyServer.Networks
{
    internal class Server
    {
        protected IScsServer _server;

        protected string bindAddress;
        protected int bindPort;
        protected int backLog;
        protected Dictionary<string, long> ConnectionTimes;

        public Server(string address, int port, int backlog)
        {
            bindAddress = address;
            bindPort = port;
            backLog = backlog;
            ConnectionTimes = new Dictionary<string, long>();

            OpCodes.Init();
            Session.SendAllThread.Start();
        }


        public void BeginListening()
        {
            _server = ScsServerFactory.CreateServer(new ScsTcpEndPoint(this.bindPort));

            _server.ClientConnected += ClientConnected;
            _server.ClientDisconnected += ClientDisconnected;

            _server.Start();
        }

        private void ClientConnected(object sender, ServerClientEventArgs e)
        {
            string ip = Regex.Match(e.Client.RemoteEndPoint.ToString(), "([0-9]+).([0-9]+).([0-9]+).([0-9]+)").Value;

            //if (ip == "159.253.18.161")
            //  return;

            Log.Info("Client connected!");

            if (ConnectionTimes.ContainsKey(ip))
            {
                if (Funcs.GetCurrentMilliseconds() - ConnectionTimes[ip] < 2000)
                {
                    /*Process.Start("cmd",
                                  "/c netsh advfirewall firewall add rule name=\"AutoBAN (" + ip +
                                  ")\" protocol=TCP dir=in remoteip=" + ip + " action=block");
                    ConnectionsTime.Remove(ip);
                    Log.Info("TcpServer: FloodAttack prevent! Ip " + ip + " added to firewall");
                    return;*/
                }
                ConnectionTimes[ip] = Funcs.GetCurrentMilliseconds();
            }
            else
                ConnectionTimes.Add(ip, Funcs.GetCurrentMilliseconds());

            new Session(e.Client);
        }

        private void ClientDisconnected(object sender, ServerClientEventArgs e)
        {
            Log.Info("Client disconnected!");
        }
    }
}
