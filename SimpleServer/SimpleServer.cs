using Packets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
namespace SimpleServer
{
    class SimpleServer
    {

        private static List<Client> clients;
        private static List<Lobby> Lobbies;
        private TcpListener tcpListener;
        private static BinaryFormatter formatter;
        public SimpleServer(string ipAddress, int port)
        {
            clients = new List<Client>();
            Lobbies = new List<Lobby>(); 
            tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
            formatter = new BinaryFormatter();
        }
        public void Start()
        {
            Console.WriteLine("Starting...");
            tcpListener.Start();
            do
            {
                Socket socket = tcpListener.AcceptSocket();
                Console.WriteLine("Connection Received!");
                Client client = new Client(socket);
                client.Send(new ChatMessagePacket("Welcome! Type !setnickname [nickname] to get started!"));
                clients.Add(client);
                Thread t = new Thread(new ParameterizedThreadStart(ClientMethod));
                t.Start(client);
            } while (true);
        }
        public void Stop()
        {
            tcpListener.Stop();
        }

        private static void ClientMethod(object clientObj)
        {
            Client client = (Client)clientObj;

            int noOfIncomingBytes;
            while((noOfIncomingBytes = client.reader.ReadInt32()) != 0)
            {
                Console.WriteLine("Received...");
                byte[] bytes = client.reader.ReadBytes(noOfIncomingBytes);
                MemoryStream memoryStream = new MemoryStream(bytes);
                Packet packet = formatter.Deserialize(memoryStream) as Packet;
                Console.WriteLine("Deserialized!");

                //checking if packet is disconnect
                if(packet.type == PacketType.DISCONNECT)
                    break;

                //since it's not a disconnect packet we can handel it.
                HandlePacket(client, packet);
            }
            
            //removes the client from the list and then closes the connect to it.
            clients.Remove(client);
            sendOnlineList(); //this sends the new list of online members out.
            client.Close();
        }


        private static void HandlePacket(Client client, Packet packet)
        {
            switch (packet.type)
            {
                case PacketType.NICKNAME:
                    Boolean duplicate = false;
                    string NickName = ((NickNamePacket)packet).nickname;

                    foreach(Client c in clients)
                    {
                        if(c.NickName.Equals(NickName)){
                            duplicate = true;
                        }
                    }

                    if (duplicate == false)
                    {
                        client.NickName = NickName;
                        ChatMessagePacket nickRecieved = new ChatMessagePacket("Info> Nickname has been set!", "Blue");
                        sendOnlineList();
                        client.Send(nickRecieved);
                        sendLobbies();
                    }
                    else{
                        ErrorMessagePacket error = new ErrorMessagePacket("Error> Nickname has been taken!");
                        client.Send(error);
                    }
                    break;
                case PacketType.CHATMESSAGE:
                    Console.WriteLine("Recieved Chat Message");
                    if (client.NickName != null)
                    {
                        string message = ((ChatMessagePacket)packet).message;
                        string color = ((ChatMessagePacket)packet).messageColor;
                        Console.WriteLine($" COLOR:{color} [{client.NickName}] {message}");
                        ChatMessagePacket chatMessage = new ChatMessagePacket($"[{client.NickName}] {message}", color);
                        foreach (Client c in clients)
                        {
                            c.Send(chatMessage); 
                        }
                    }
                    else
                    {
                        ChatMessagePacket nickNameError = new ChatMessagePacket("SET A NICKNAME BEFORE CHATTING WITH !setnickname [NICKNAME] Or via the Lobby GUI");
                        client.Send(nickNameError);
                    }
                    break;
                case PacketType.CREATELOBBY:
                    Console.WriteLine("Lobby Created by: " + client.NickName);
                    Lobby lobby = new Lobby((Lobbies.Count + 1), client);
                    Lobbies.Add(lobby);

                    client.Send(new CreateLobbyPacket(client.NickName));
                    sendLobbies();
                    lobby.sendList();
                    break;
                case PacketType.LEAVELOBBY:
                    foreach (Lobby l in Lobbies.ToArray())
                    {
                        if (l.creator.NickName.Equals(client.NickName))
                        {
                            l.creator = null;
                            checkLobbyNotEmpty();
                            l.sendList();
                        }
                        else if (l.other != null)
                        {
                            if (l.other.NickName.Equals(client.NickName))
                            {
                                l.other = null;
                                checkLobbyNotEmpty();
                                l.sendList();
                            }
                        }
                    }
                    sendLobbies();
                    break;
                case PacketType.JOINLOBBY:
                    string creator = (((JoinLobbyPacket)packet).creator);
                    Console.WriteLine("Client " + client.NickName + " Joined Lobby created by: " + creator);
                    foreach(Lobby l in Lobbies)
                    {
                        if (l.creator.NickName.Equals(creator))
                        {
                            client.Send(new JoinLobbyPacket(""));
                            l.addOther(client);
                        }
                    }
                    break;
                case PacketType.START:
                    foreach(Lobby l in Lobbies)
                    {
                        if (l.creator.NickName.Equals(client.NickName))
                        {
                            l.start();
                            break;
                        }
                        client.Send(new ErrorMessagePacket("Error> You are not the creator of the lobby!"));
                    }
                    break;
                case PacketType.OPTION:
                    foreach (Lobby l in Lobbies)
                    {
                        Console.WriteLine(((OptionPickPacket)packet).Option);
                        if (l.creator.NickName.Equals(client.NickName))
                        {
                            l.setCreatorPick(((OptionPickPacket)packet).Option);
                        }
                        else if(l.other.NickName.Equals(client.NickName))
                        {
                            l.setOtherPick(((OptionPickPacket)packet).Option);
                        }
                    }
                    break;
                case PacketType.FORCEQUIT:
                    foreach (Lobby l in Lobbies.ToArray())
                    {
                        if (l.creator.NickName.Equals(client.NickName) || l.other.NickName.Equals(client.NickName))
                        {
                            l.forceQuit(client);
                            Lobbies.Remove(l);
                            break;
                        }
                    }
                    break;
                case PacketType.EMPTY:
                    Console.WriteLine("Blank Packet");
                    break;
                default:
                    Console.WriteLine("Error Packet Type Unknown");
                    break;
            }

        }

        private static void sendOnlineList()
        {
            //recreates the string list 
            List<string> OnlineUsers = new List<string>();
            foreach(Client c in clients){
                OnlineUsers.Add(c.NickName);
            }

            foreach (Client c in clients)
            {
                OnlineUsersPacket onlinePacket = new OnlineUsersPacket(OnlineUsers);
                c.Send(onlinePacket);
            }

        }

        private static void sendLobbies()
        {
            List<String> creators = new List<String>();
            foreach (Lobby l in Lobbies)
            {
                creators.Add(l.creator.NickName);
            }
            foreach (Client c in clients)
            {
                c.Send(new LobbyListPacket(creators));
            }
        }

        private static void checkLobbyNotEmpty()
        {
            foreach(Lobby l in Lobbies.ToArray())
            {
                if (l.creator == null && l.other == null)
                {
                    Lobbies.Remove(l);
                }
                else if( l.creator == null && l.other != null)
                {
                    l.creator = l.other;
                    l.other = null;

                }
            }
        }

    }
}
