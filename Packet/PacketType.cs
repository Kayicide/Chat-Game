using System;
using System.Collections.Generic;
using System.Text;

namespace Packet
{
    [Serializable]
    public enum PacketType
    {
        EMPTY,
        NICKNAME,
        CHATMESSAGE,
    }
}
