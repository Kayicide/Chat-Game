using System;
using System.Collections.Generic;
using System.Text;

namespace Packet
{
    [Serializable]
    class Packet
    {
        public PacketType type = PacketType.EMPTY;
    }
}
