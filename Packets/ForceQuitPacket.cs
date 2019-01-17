using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class ForceQuitPacket : Packet
    {
        public ForceQuitPacket()
        {
            this.type = PacketType.FORCEQUIT;
        }
    }
}
