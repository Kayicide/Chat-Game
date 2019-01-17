using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Packets;
using System.Threading.Tasks;

namespace SimpleServer
{
    class Client
    {
        private Socket socket;
        private NetworkStream stream;
        public BinaryReader reader { get; private set; }
        public BinaryWriter writer { get; private set; }
        public string NickName { get; set;}
        public BinaryFormatter formatter;

        public Client(Socket socket)
        {
            this.NickName = "";
            this.socket = socket;
            formatter = new BinaryFormatter();
            stream = new NetworkStream(this.socket);
            reader = new BinaryReader(stream, Encoding.UTF8);
            writer = new BinaryWriter(stream, Encoding.UTF8);
        }

        public void Send(Packet packet)
        {
            Console.WriteLine("SEND");
            MemoryStream memStream = new MemoryStream();
            formatter.Serialize(memStream, packet);
            Byte[] buffer = memStream.GetBuffer();
            writer.Write(buffer.Length);
            writer.Write(buffer);
            writer.Flush();
        }

        public void Close()
        {
            writer.Write(0);
            stream.Close();
            socket.Close();
        }
    }
}
