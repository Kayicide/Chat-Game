using Packets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleChat
{
    class SimpleClient
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private BinaryWriter writer;
        private BinaryReader reader;
        private BinaryFormatter formatter;
        public static Boolean connected;
        public ChatClient chat;
        public Lobby lobby;
        public string message { get; set; }

        public SimpleClient()
        {
            formatter = new BinaryFormatter();
            tcpClient = new TcpClient();
        }
        public bool Connect(string ipAddress, int port)
        {
            try
            {
                Console.WriteLine("Connecting...");
                tcpClient.Connect(ipAddress, port);
                stream = tcpClient.GetStream();
                reader = new BinaryReader(stream, Encoding.UTF8);
                writer = new BinaryWriter(stream, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
                return false;
            }
            Console.WriteLine("Connected!");
            connected = true;
            return true;
        }

        public void Start()
        {
            chat = new ChatClient(writer);
            lobby = new Lobby(writer);
            Thread ui = new Thread(new ThreadStart(UIRun));
            Thread read = new Thread(new ThreadStart(readMessage));
            ui.Start();
            read.Start();
        }

        private void readMessage()
        {
            int noOfIncomingBytes;
            try
            {
                while ((noOfIncomingBytes = reader.ReadInt32()) != 0)
                {
                    Console.WriteLine("Received...");
                    byte[] bytes = reader.ReadBytes(noOfIncomingBytes);
                    MemoryStream memoryStream = new MemoryStream(bytes);
                    Packet packet = formatter.Deserialize(memoryStream) as Packet;
                    Console.WriteLine("Deserialized!");
                    packetHandle(packet);
                }
                stream.Close();
            }
            catch (IOException e){
                chat.UpdateChatWindow("ERROR LOST CONNECTION TO SERVER RESTART TO FIX", "Red");
            }
        }



        private void packetHandle(Packet packet)
        {
            switch (packet.type)
            {
                case PacketType.CHATMESSAGE:
                    chat.UpdateChatWindow(((ChatMessagePacket)packet).message, ((ChatMessagePacket)packet).messageColor);
                    break;
                case PacketType.ONLINEUSERS:
                    Console.WriteLine("Recieved OnlineUsers");
                    chat.addUserOnline(((OnlineUsersPacket)packet).OnlineNicknames);
                    break;
                case PacketType.LOBBYLIST:
                    lobby.addLobbysOnline(((LobbyListPacket)packet).creators);
                    break;
                case PacketType.CREATELOBBY:
                    Console.WriteLine("CREATE LOBBY PACKET");
                    break;
                case PacketType.JOINLOBBY:
                    Console.WriteLine("JOIN LOBBY PACKET");
                    lobby.joinSpaceAvailable();
                    break;
                case PacketType.LOBBYPLAYERLIST:
                    Console.WriteLine("LOBBYPLAYERLIST");
                    lobby.waitingLobby.addUser(((LobbyPlayersPacket)packet).players);
                    break;
                case PacketType.START:
                    Console.WriteLine("START GAME");
                    lobby.waitingLobby.start();
                    break;
                case PacketType.FORCEQUIT:
                    lobby.waitingLobby.otherQuit();
                    break;
                case PacketType.ERRORMESSAGE:
                    chat.UpdateChatWindow(((ErrorMessagePacket)packet).message, ((ErrorMessagePacket)packet).messageColor);
                    Console.WriteLine(((ErrorMessagePacket)packet).message);
                    break;
                case PacketType.WINNER:
                    Console.WriteLine("Got winners");
                    lobby.waitingLobby.game.winnerPacket(((WinnerPacket)packet).winner, ((WinnerPacket)packet).otherPick);
                    break;
                default:
                    Console.WriteLine("Unknown packet type recieved!");
                    Console.WriteLine(packet.type.ToString());
                    break;
            }
        }
        private void UIRun()
        {

            chat.Show();
            chat.Hide();
            Application.Run(lobby);
        }


    }
}
