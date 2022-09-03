using Hik.Communication.Scs.Server;
using LobbyServer.Networks.Messages;
using LobbyServer.Networks.Protocols;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using Utility;

namespace LobbyServer.Networks
{
    public class Client
    {
        public static List<Client> Clients = new List<Client>();

        public static Thread SendAllThread = new Thread(SendAll);

        private static void SendAll()
        {
            while (true)
            {
                for (int i = 0; i < Clients.Count; i++)
                {
                    try
                    {
                        if (!Clients[i].Send())
                            Clients.RemoveAt(i--);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorException("Client: SendAll:", ex);
                    }
                }

                Thread.Sleep(10);
            }
        }


        protected IScsServerClient scsClient;

        public byte[] Buffer;

        protected List<byte[]> SendData = new List<byte[]>();

        protected int SendDataSize;

        protected object SendLock = new object();


        public Client(IScsServerClient client)
        {
            scsClient = client;
            scsClient.WireProtocol = new GameProtocol();

            scsClient.Disconnected += OnDisconnected;
            scsClient.MessageReceived += OnMessageReceived;
        }

        private void OnMessageReceived(object sender, Hik.Communication.Scs.Communication.Messages.MessageEventArgs e)
        {
            GameMessage message = (GameMessage)e.Message;
            Buffer = message.Data;

            Console.WriteLine(Buffer.FormatHex());

            if (OpCodes.Recv.ContainsKey(message.OpCode))
            {
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
            return true;
        }

        public void PushPacket(byte[] data)
        {
            if (SendLock == null)
                return;

            lock (SendLock)
            {
                short opCode = BitConverter.ToInt16(data, 2);
                SendData.Add(data);
                SendDataSize += data.Length;
            }
        }
    }
}
