using System;
using System.Collections.Generic;
using System.Text;

namespace PacketStuff
{
    [Serializable]
    public class ChatMessagePacket : Packet
    {
        public string message;
        public ChatMessagePacket(string message)
        {
            this.type = PacketType.CHATMESSAGE;
            this.message = message;
        }
    }
}
