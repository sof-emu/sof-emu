using Data.Interfaces;
using System;
using System.IO;
using System.Text;
using Utility;

namespace GameServer.Networks.Packets
{
    public abstract class ASendPacket : ISendPacket
    {

        protected byte[] Data;
        protected object WriteLock = new object();

        public void Send(ISession state)
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
                                WriteH(writer, 0); //Reserved for packet length
                                WriteH(writer, state.SessionId); // object uid
                                WriteH(writer, OpCodes.Send[GetType()]);
                                WriteH(writer, 0); //Reserved for data length
                                Write(writer);
                            }

                            Data = stream.ToArray();
                            BitConverter.GetBytes((short)(Data.Length - 2)).CopyTo(Data, 0);
                            BitConverter.GetBytes((short)(Data.Length - 8)).CopyTo(Data, 6);

                            //Log.Debug(Data.FormatHex());
                            WriteScope(ref Data);
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

            state.SendPacket(Data);
        }

        public void WriteScope(ref byte[] Data)
        {
            byte[] start_scope = new byte[2] { 0xAA, 0x55 };
            byte[] end_scope = new byte[2] { 0x55, 0xAA };
            byte[] buffer = new byte[Data.Length + 4];
            Buffer.BlockCopy(start_scope, 0, buffer, 0, 2);
            Buffer.BlockCopy(Data, 0, buffer, 2, Data.Length);
            Buffer.BlockCopy(end_scope, 0, buffer, Data.Length + 2, 2);
            Data = buffer;
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

        protected void WriteH(BinaryWriter writer, int val)
        {
            writer.Write((short)val);
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

        protected void WriteSH(BinaryWriter writer, String text)
        {
            if (text.Length > 0)
            {
                writer.Write((short)text.Length);
                writer.Write(Encoding.Default.GetBytes(text));
            }
        }

        protected void WriteSN(BinaryWriter writer, String text)
        {
            byte[] names = Encoding.Default.GetBytes(text);
            byte[] val = new byte[15];
            Buffer.BlockCopy(names, 0, val, 0, names.Length);
            writer.Write(val);
        }
        
        protected void WriteSL(BinaryWriter writer, String text, int length)
        {
            byte[] names = Encoding.Default.GetBytes(text);
            byte[] val = new byte[length];
            Buffer.BlockCopy(names, 0, val, 0, names.Length);
            writer.Write(val);
        }

        protected void WriteB(BinaryWriter writer, string hex)
        {
            writer.Write(hex.ToBytes());
        }

        protected void WriteB(BinaryWriter writer, byte[] data)
        {
            writer.Write(data);
        }

        protected void WriteItemInfo(BinaryWriter writer, object item)
        {
            if (item != null)
            {
                /*
                WriteQ(writer, item.ObjectId);
                WriteQ(writer, item.ItemId);
                WriteD(writer, item.Amount); // Amount
                WriteD(writer, item.Magic0); // FLD_MAGIC0
                WriteD(writer, item.Magic1); // FLD_MAGIC1
                WriteD(writer, item.Magic2); // FLD_MAGIC2
                WriteD(writer, item.Magic3); // FLD_MAGIC3
                WriteD(writer, item.Magic4); // FLD_MAGIC4
                WriteH(writer, 0);
                WriteH(writer, 0); // (IsBlue == true ? 1 : 0)
                WriteH(writer, item.BonusMagic1); // BonusMagic1
                WriteH(writer, item.BonusMagic2); // BonusMagic2
                WriteH(writer, item.BonusMagic3); // BonusMagic3
                WriteH(writer, item.BonusMagic4); // BonusMagic4
                WriteH(writer, item.BonusMagic5); // BonusMagic5
                WriteD(writer, 0);
                WriteD(writer, (item.LimitTime > 0 ? 1 : 0));
                WriteD(writer, item.LimitTime);
                WriteH(writer, item.Upgrade);
                WriteH(writer, 0); // ItemType : item.ItemTemplate.Category
                WriteH(writer, 0); // 0
                WriteH(writer, 0);
                WriteQ(writer, 0);
                WriteB(writer, new byte[6]);
                */
            }
            else
                WriteB(writer, new byte[88]);
        }
    }
}
