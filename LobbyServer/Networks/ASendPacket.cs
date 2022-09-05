using Data.Interfaces;
using System;
using System.IO;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using Utility;

namespace LobbyServer.Networks
{
    public abstract class ASendPacket : ISendPacket
    {

        protected byte[] Data;
        protected object WriteLock = new object();

        public void Send(Session state)
        {
            if (state == null)
                return;

            if (!OpCodes.Send.ContainsKey(GetType()))
            {
                Log.Warn("UNKNOWN packet opcode: {0}", GetType().Name);
                return;
            }


            lock (WriteLock)
            {
                if (Data == null)
                {
                    try
                    {
                        Log.Info("Write packet: {0}", GetType().Name);

                        using (MemoryStream stream = new MemoryStream())
                        {
                            using (BinaryWriter writer = new BinaryWriter(stream, new UTF8Encoding()))
                            {
                                WriteH(writer, OpCodes.Send[GetType()]);
                                WriteH(writer, 0); //Reserved for length
                                Write(writer);
                            }

                            Data = stream.ToArray();
                            BitConverter.GetBytes((short)(Data.Length - 4)).CopyTo(Data, 2);

                            Log.Debug(Data.FormatHex());
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Warn("Can't write packet: {0}", GetType().Name);
                        Log.WarnException("ASendPacket", ex);
                        return;
                    }
                }
            }

            state.PushPacket(Data);
        }

        public abstract void Write(BinaryWriter writer);

        protected void WriteD(BinaryWriter writer, int val)
        {
            writer.Write(val);
        }

        protected void WriteH(BinaryWriter writer, short val)
        {
            writer.Write(val);
        }

        protected void WriteC(BinaryWriter writer, byte val)
        {
            writer.Write(val);
        }

        protected void WriteDf(BinaryWriter writer, double val)
        {
            writer.Write(val);
        }

        protected void WriteF(BinaryWriter writer, float val)
        {
            writer.Write(val);
        }

        protected void WriteQ(BinaryWriter writer, long val)
        {
            writer.Write(val);
        }

        protected void WriteS(BinaryWriter writer, String text)
        {
            if (text == null)
            {
                writer.Write((short)0);
            }
            else
            {
                Encoding encoding = Encoding.Default;
                writer.Write((short)text.Length);
                writer.Write(encoding.GetBytes(text));
            }
        }

        protected void WriteB(BinaryWriter writer, string hex)
        {
            writer.Write(hex.ToBytes());
        }

        protected void WriteB(BinaryWriter writer, byte[] data)
        {
            writer.Write(data);
        }
    }
}
