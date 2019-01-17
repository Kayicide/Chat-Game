using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class OptionPickPacket : Packet
    {
        public string Option = string.Empty;
        public OptionPickPacket(string Option)
        {
            this.type = PacketType.OPTION;
            this.Option = Option;
        }
    }
}
