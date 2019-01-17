using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class LobbyPlayersPacket : Packet
    {
        public List<string> players;
        public LobbyPlayersPacket(List<string> players)
        {
            this.players = players;
            type = PacketType.LOBBYPLAYERLIST;
        }
    }
}
