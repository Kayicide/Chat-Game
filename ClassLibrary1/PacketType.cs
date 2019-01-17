using System;
using System.Collections.Generic;
using System.Text;

namespace PacketManager
{
    [Serializable]
    public enum PacketType
    {
        EMPTY,
        NICKNAME,
        CHATMESSAGE,
    }
}
