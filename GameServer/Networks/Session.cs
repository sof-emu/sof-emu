using GameServer.Networks.Messages;
using GameServer.Networks.Packets;
using GameServer.Networks.Protocols;
using Hik.Communication.Scs.Server;
using System;
using System.Collections.Generic;
using Utility;

namespace GameServer.Networks
{
    public class Session
    {
        public static List<Session> Sessions = new List<Session>();

        private IScsServerClient Client;
        private IScsServer Channel;

        public byte[] Buffer;
        protected List<byte[]> SendData = new List<byte[]>();
        protected int SendDataSize;
        protected object SendLock = new object();

        public int hash = 0;

        public Session(IScsServerClient client, IScsServer channel)
        {
            Client = client;
            Channel = channel;

            Client.WireProtocol = new GameProtocol();
            Client.Disconnected += OnDisconnected;
            Client.MessageReceived += OnMessageReceived;

            Sessions.Add(this);
        }

        private void OnMessageReceived(object sender, Hik.Communication.Scs.Communication.Messages.MessageEventArgs e)
        {
            GameMessage message = (GameMessage)e.Message;
            Buffer = message.Data;

            if(hash == 0)
                hash = message.Hash;

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

        private void OnDisconnected(object sender, System.EventArgs e)
        {
            
        }

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
    }
}