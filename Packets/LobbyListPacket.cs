using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class LobbyListPacket : Packet
    {
        public List<String> creators;

        public LobbyListPacket(List<String> creators)
        {
            this.creators = creators;
            type = PacketType.LOBBYLIST;
        }
    }
}
