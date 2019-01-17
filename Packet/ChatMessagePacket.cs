using System;
using System.Collections.Generic;
using System.Text;

namespace Packet
{
    [Serializable]
    class ChatMessagePacket : Packet
    {
        public string message = String.Empty;
        public ChatMessagePacket(string message)
        {
            this.type = PacketType.CHATMESSAGE;
            this.message = message;
        }
    }
}
