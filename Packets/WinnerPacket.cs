using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public class WinnerPacket : Packet
    {
        public int winner;
        public string otherPick;
        public WinnerPacket(int winner, string otherPick)
        {
            this.type = PacketType.WINNER;
            this.winner = winner;
            this.otherPick = otherPick;
        }
    }
}
