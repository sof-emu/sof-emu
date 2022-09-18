using Data;
using GameServer.Networks.Messages;
using Hik.Communication.Scs.Communication.Messages;
using Hik.Communication.Scs.Communication.Protocols;
using System;
using System.Collections.Generic;
using System.IO;
using Utility;

namespace GameServer.Networks.Protocols
{
    public class GameProtocol : IScsWireProtocol
    {
        /// <summary>
        /// 
        /// </summary>
        protected MemoryStream Stream = new MemoryStream();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedBytes"></param>
        /// <returns></returns>
        public IEnumerable<IScsMessage> CreateMessages(byte[] receivedBytes)
        {
            byte[] unpackBytes = new byte[receivedBytes.Length - 4];
            Buffer.BlockCopy(receivedBytes, 2, unpackBytes, 0, unpackBytes.Length);

            Stream.Write(unpackBytes, 0, unpackBytes.Length);
            List<IScsMessage> messages = new List<IScsMessage>();
            while (ReadMessage(messages)) ;
            return messages;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        private bool ReadMessage(List<IScsMessage> messages)
        {
            Stream.Position = 0;

            if (Stream.Length < 8)
                return false;

            byte[] headerBytes = new byte[8];
            Stream.Read(headerBytes, 0, 8);

            ushort opcode = BitConverter.ToUInt16(headerBytes, 4);
            int length = BitConverter.ToUInt16(headerBytes, 6);

            if (Stream.Length < length)
                return false;

            if (opcode == 0x0001 && length == 0)
                return false;

            GameMessage message = new GameMessage
            {
                OpCode = (short)opcode,
                Data = new byte[length]
            };

            Stream.Read(message.Data, 0, message.Data.Length);

            messages.Add(message);

            TrimStream();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void TrimStream()
        {
            if (Stream.Position == Stream.Length)
            {
                Stream = new MemoryStream();
                return;
            }

            byte[] remaining = new byte[Stream.Length - Stream.Position];
            Stream.Read(remaining, 0, remaining.Length);

            string bytesString = BitConverter.ToString(remaining).Replace("-", "");
            bytesString = bytesString.ReplaceFirst("55AAAA55", "");
            remaining = bytesString.ToBytes();

            Stream = new MemoryStream();
            Stream.Write(remaining, 0, remaining.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public byte[] GetBytes(IScsMessage message)
        {
            return ((GameMessage)message).Data;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
        }
    }
}
