﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class StartPacket : Packet
    {
        public StartPacket()
        {
            this.type = PacketType.START;
        }
    }
}
