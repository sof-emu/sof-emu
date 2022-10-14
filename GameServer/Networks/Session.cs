using Data.Interfaces;
using Data.Structures.Account;
using Data.Structures.Player;
using GameServer.Networks.Messages;
using GameServer.Networks.Packets;
using GameServer.Networks.Protocols;
using Hik.Communication.Scs.Server;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Utility;

namespace GameServer.Networks
{
    public class Session : ISession
    {
        public static List<Session> Sessions = new List<Session>();

        private IScsServerClient Client;
        private IScsServer Channel;

        public byte[] Buffer;
        public GameMessage Message;
        protected List<byte[]> SendData = new List<byte[]>();
        protected int SendDataSize;
        protected object SendLock = new object();

        protected int _sessionId;
        protected DateTime _lastPing;

        // Game Properties
        protected Account account;
        public Player Player { get; set; }
        protected SettingOption setting;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="channel"></param>
        public Session(IScsServerClient client, IScsServer channel)
        {
            Client = client;
            Channel = channel;

            //players = new Dictionary<int, Player>();

            Client.WireProtocol = new GameProtocol();
            Client.Disconnected += OnDisconnected;
            Client.MessageReceived += OnMessageReceived;

            Sessions.Add(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public Account Account
        {
            get { return account; }
            set
            {
                if (value.Session != null)
                    value.Session.Close();

                account = value;
                account.Session = this;
            }
        }

        public bool IsValid
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMessageReceived(object sender, Hik.Communication.Scs.Communication.Messages.MessageEventArgs e)
        {
            Message = (GameMessage)e.Message;
            Buffer = Message.Data;

            //if(hash == 0)
            //    hash = message.Hash;

            if (OpCodes.Recv.ContainsKey(Message.Opcode))
            {
                string name = OpCodes.RecvNames[Message.Opcode];
                string opCodeLittleEndianHex = BitConverter.GetBytes(Message.Opcode).ToHex();
                Log.Debug("Received packet opcode: {0}|0x{1}{2} [{3}]",
                                 name,
                                 opCodeLittleEndianHex.Substring(2),
                                 opCodeLittleEndianHex.Substring(0, 2),
                                 Buffer.Length);

                ((ARecvPacket)Activator.CreateInstance(OpCodes.Recv[Message.Opcode])).Process(this);
            }
            else
            {
                string opCodeLittleEndianHex = BitConverter.GetBytes(Message.Opcode).ToHex();
                Log.Debug("Unknown GsPacket opCode: 0x{0}{1} [{2}]",
                                 opCodeLittleEndianHex.Substring(2),
                                 opCodeLittleEndianHex.Substring(0, 2),
                                 Buffer.Length);

                Log.Debug("Data:\n{0}", Buffer.FormatHex());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDisconnected(object sender, System.EventArgs e)
        {
            // todo save data
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void SendPacket(byte[] data)
        {
            if (SendLock == null)
                return;

            lock (SendLock)
            {
                GameMessage message = new GameMessage { Data = data };

                try
                {
                    //Log.Debug($"Send Message: {Environment.NewLine}{message.Data.FormatHex()}");
                    Client.SendMessage(message);
                }
                catch
                {
                    //Already closed
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            if (account != null)
                account.lastOnlineUtc = Funcs.GetCurrentMilliseconds();

            Client.Disconnect();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long Ping()
        {
            Ping ping = new Ping();

            //"tcp://127.0.0.1:27230"
            string ipAddress = Client.RemoteEndPoint.ToString().Substring(6);
            ipAddress = ipAddress.Substring(0, ipAddress.IndexOf(':'));

            PingReply pingReply = ping.Send(ipAddress);

            return (pingReply != null) ? pingReply.RoundtripTime : 0;
        }
    }
}