using Hik.Communication.Scs.Communication;
using Hik.Communication.Scs.Server;
using LobbyServer.Networks.Messages;
using LobbyServer.Networks.Protocols;
using LobbyServer.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using Utility;

namespace LobbyServer.Networks
{
    public class Session
    {
        public static List<Session> Sessions = new List<Session>();
        public static Thread SendAllThread = new Thread(SendAll);

        protected IScsServerClient Client;
        public byte[] Buffer;
        protected List<byte[]> SendData = new List<byte[]>();
        protected int SendDataSize;
        protected object SendLock = new object();

        public Session(IScsServerClient client)
        {
            Client = client;
            Client.WireProtocol = new GameProtocol();
            Client.Disconnected += OnDisconnected;
            Client.MessageReceived += OnMessageReceived;

            Sessions.Add(this);
        }

        private void OnMessageReceived(object sender, Hik.Communication.Scs.Communication.Messages.MessageEventArgs e)
        {
            GameMessage message = (GameMessage)e.Message;
            Buffer = message.Data;

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

        private void OnDisconnected(object sender, EventArgs e)
        {
            
        }

        private bool Send()
        {
            GameMessage message;

            if (SendLock == null)
            {
                return false;
            }
                

            lock (SendLock)
            {
                if (SendData.Count == 0)
                {
                    return Client.CommunicationState == CommunicationStates.Connected;
                }
                    
                message = new GameMessage { Data = new byte[SendDataSize] };

                int pointer = 0;
                for (int i = 0; i < SendData.Count; i++)
                {
                    Array.Copy(SendData[i], 0, message.Data, pointer, SendData[i].Length);
                    pointer += SendData[i].Length;
                }

                SendData.Clear();
                SendDataSize = 0;
            }

            try
            {
                Log.Debug($"Send Message: {message.Data.FormatHex()}");
                Client.SendMessage(message);
            }
            catch
            {
                //Already closed
                return false;
            }

            return true;
        }

        public void PushPacket(byte[] data)
        {
            if (SendLock == null)
                return;

            lock (SendLock)
            {
                SendData.Add(data);
                SendDataSize += data.Length;
            }
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

        public bool IsValid
        {
            get { return true; }
        }

        public void Close()
        {
            //if (_account != null)
               // _account.LastOnlineUtc = Funcs.GetCurrentMilliseconds();

            Client.Disconnect();
        }

        private static void SendAll()
        {
            while (true)
            {
                for (int i = 0; i < Sessions.Count; i++)
                {
                    try
                    {
                        if (!Sessions[i].Send())
                            Sessions.RemoveAt(i--);
                            
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorException("Client: SendAll:", ex);
                    }
                }

                Thread.Sleep(50);
            }
        }
    }
}
