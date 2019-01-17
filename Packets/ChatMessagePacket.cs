using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class ChatMessagePacket : Packet
    {
        public string message = string.Empty;
        public string messageColor = "Black";

        public ChatMessagePacket(string message)
        {
            this.type = PacketType.CHATMESSAGE;
            this.message = message;
        }
        public ChatMessagePacket(string message, string messageColor)
        {
            this.type = PacketType.CHATMESSAGE;
            this.message = message;
            this.messageColor = messageColor;
        }
    }
}
