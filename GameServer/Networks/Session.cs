using Data.Interfaces;
using Data.Models.Account;
using Data.Models.Player;
using GameServer.Networks.Messages;
using GameServer.Networks.Packets;
using GameServer.Networks.Protocols;
using Hik.Communication.Scs.Server;
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected AccountData account;
        protected Dictionary<int, Player> players = new Dictionary<int, Player>();
        protected Player selectedPlayer;
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

            _sessionId = GameServer
                .IDFactory
                .GetNext();

            Client.WireProtocol = new GameProtocol();
            Client.Disconnected += OnDisconnected;
            Client.MessageReceived += OnMessageReceived;

            Sessions.Add(this);
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
                    Log.Debug($"Send Message: {Environment.NewLine}{message.Data.FormatHex()}");
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
        public short SessionId
        {
            get { return (short)_sessionId; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AccountData GetAccount()
        {
            return account;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acc"></param>
        public void SetAccount(AccountData acc)
        {
            account = acc;
        }

        /// <summary>
        /// Get List of Player
        /// </summary>
        /// <returns>List<Player></returns>
        public List<Player> GetPlayers()
        {
            return players
                .Values
                .ToList();
        }

        /// <summary>
        /// Get Player by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Player</returns>
        public Player GetPlayer(int index)
        {
            return players[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="players"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetPlayer(List<Player> players)
        {
            this.players = players.Distinct().ToDictionary(i => i.Index, i => i); ;
        }

        /// <summary>
        /// Add Player to Dictionary
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player)
        {
            players.Add(player.Index, player);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        public void SetSelectPlayer(Player player)
        {
            selectedPlayer = player;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Player GetSelectedPlayer()
        {
            return selectedPlayer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="setting"></param>
        public void SetSetting(SettingOption setting)
        {
            this.setting = setting;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SettingOption GetSetting()
        {
            return setting;
        }

        /// <summary>
        /// Set DateTime of lastping
        /// </summary>
        /// <param name="last"></param>
        public void SetLastPing(DateTime last)
        {
            _lastPing = last;
        }

        /// <summary>
        /// Get Last Ping DateTime
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public DateTime GetLastPing()
        {
            return _lastPing;
        }
    }
}