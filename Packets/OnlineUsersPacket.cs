using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class OnlineUsersPacket : Packet
    {
        public List<string> OnlineNicknames = new List<string>();
        public OnlineUsersPacket(List<string> OnlineNicknames)
        {
            this.OnlineNicknames = OnlineNicknames;
            type = PacketType.ONLINEUSERS;
        }
    }
}
