using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class CreateLobbyPacket : Packet
    {
        public string creatorNick;
        public CreateLobbyPacket()
        {
            type = PacketType.CREATELOBBY;
        }
        public CreateLobbyPacket(string creatorNick)
        {
            type = PacketType.CREATELOBBY;
            this.creatorNick = creatorNick;
        }
    }
}
