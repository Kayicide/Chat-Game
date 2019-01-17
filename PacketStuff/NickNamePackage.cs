using System;
using System.Collections.Generic;

namespace PacketStuff
{
    [Serializable]
    public class NickNamePackage : Packet
    {
        public string nickName = String.Empty;
        public NickNamePackage(string nickName)
        {
            this.type = PacketType.NICKNAME;
            this.nickName = nickName;
        }
    }
}
