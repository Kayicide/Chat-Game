using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class JoinLobbyPacket : Packet
    {
        public string creator;
        public JoinLobbyPacket(string creator)
        {
            this.creator = creator;
            type = PacketType.JOINLOBBY;
        }
    }
}
