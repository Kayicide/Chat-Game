using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class ErrorMessagePacket : Packet
    {
        public string message = string.Empty;
        public string messageColor;
        public ErrorMessagePacket(string message)
        {
            this.type = PacketType.ERRORMESSAGE;
            this.messageColor = "Red";
            this.message = message;
        }
    }
}
