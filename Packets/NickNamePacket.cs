using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class NickNamePacket : Packet
    {
        public string nickname = string.Empty;
        public NickNamePacket(string nickname)
        {
            this.type = PacketType.NICKNAME;
            this.nickname = nickname;
        }
    }
}
