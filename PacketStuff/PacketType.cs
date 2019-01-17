using System;
using System.Collections.Generic;
using System.Text;

namespace PacketStuff
{
    [Serializable]
    public enum PacketType
    {
        EMPTY,
        NICKNAME,
        CHATMESSAGE,
    }
}
