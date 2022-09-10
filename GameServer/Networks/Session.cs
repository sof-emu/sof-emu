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
        protected List<byte[]> SendData = new List<byte[]>();
        protected int SendDataSize;
        protected object SendLock = new object();

        protected AccountData account;
        protected Dictionary<int, Player> players;
        protected Player selectedPlayer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="channel"></param>
        public Session(IScsServerClient client, IScsServer channel)
        {
            Client = client;
            Channel = channel;

            Client.WireProtocol = new GameProtocol();
            Client.Disconnected += OnDisconnected;
            Client.MessageReceived += OnMessageReceived;

            Sessions.Add(this);

            players = new Dictionary<int, Player>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMessageReceived(object sender, Hik.Communication.Scs.Communication.Messages.MessageEventArgs e)
        {
            GameMessage message = (GameMessage)e.Message;
            Buffer = message.Data;

            //if(hash == 0)
            //    hash = message.Hash;

            if (OpCodes.Recv.ContainsKey(message.OpCode))
            {
                string opCodeLittleEndianHex = BitConverter.GetBytes(message.OpCode).ToHex();
                Log.Debug("Received packet opcode: 0x{0}{1} [{2}]",
                                 opCodeLittleEndianHex.Substring(2),
                                 opCodeLittleEndianHex.Substring(0, 2),
                                 Buffer.Length);

                ((ARecvPacket)Activator.CreateInstance(OpCodes.Recv[message.OpCode])).Process(this);
            }
            else
            {
                string opCodeLittleEndianHex = BitConverter.GetBytes(message.OpCode).ToHex();
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
                    Log.Debug($"Send Message: {message.Data.FormatHex()}");
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
            get { return (short)Client.ClientId; }
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
        public Player GetPlayer(int id)
        {
            return players[id];
        }

        /// <summary>
        /// Add Player to Dictionary
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player)
        {
            players.Add(player.Id, player);
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
    }
}