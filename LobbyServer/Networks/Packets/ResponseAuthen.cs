using System;
using System.IO;
using System.Text;
using Utility;

namespace LobbyServer.Networks.Packets
{
    public class ResponseAuthen : ASendPacket
    {
        protected ResponseAuthenType Type;
        protected string message;

        public ResponseAuthen(ResponseAuthenType type, string msg = "")
        {
            Type = type;
            message = msg;
        }

        public override void Write(BinaryWriter writer)
        {
            switch(Type)
            {
                case ResponseAuthenType.Success:
                    WriteH(writer, 0);
                    WriteC(writer, 0);
                    break;
                case ResponseAuthenType.WrongPassword:
                    WriteH(writer, 10);
                    WriteC(writer, 0);
                    break;
                case ResponseAuthenType.Error:
                    WriteH(writer, 23);
                    WriteS(writer, message);
                    WriteC(writer, 0);
                    break;
            }
            
        }
    }

    public enum ResponseAuthenType
    {
        Success,
        WrongPassword,
        Banned,
        Error
    }
}
