using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packets
{
    [Serializable]
    public enum PacketType
    {
        EMPTY, 
        NICKNAME, 
        CHATMESSAGE,
        ONLINEUSERS,
        DISCONNECT,
        ERRORMESSAGE,
        LOBBYLIST,
        CREATELOBBY,
        LEAVELOBBY,
        JOINLOBBY,
        LOBBYPLAYERLIST,
        START,
        FORCEQUIT,
        WINNER,
        OPTION
    }
}
