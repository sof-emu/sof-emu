using System;
using System.IO;

namespace GameServer.Networks.Packets.Response
{
    public class ResponseStealth : ASendPacket
    {
        public ResponseStealth()
        {

        }

        public override void Write(BinaryWriter writer)
        {
            // AA551A00B20205200C00060000000100000001000000000000000000000055AA
            // d d d
            throw new NotImplementedException();
        }
    }
}
