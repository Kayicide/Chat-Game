using System;
using System.Collections.Generic;
using System.Text;

namespace Packet
{
    [Serializable]
    class NickNamePackage : Packet
    {
        public string nickName = String.Empty;
        public NickNamePackage(string nickName)
        {
            this.type = PacketType.NICKNAME;
            this.nickName = nickName;
        }
    }
}
