using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packets;

namespace SimpleServer
{
    class Lobby
    {
        public Client creator { get; set; } = null;
        public Client other { get; set; } = null;
        public int lobbyID { get; private set; }

        public string creatorPick { get; private set; } = null;
        public string otherPick { get; private set; } = null;
        public Boolean full { get; private set; } = false;

       public Boolean running { get; private set; } = false;

        public Lobby(int id, Client creator)
        {
            this.creator = creator;
            this.lobbyID = id;
        }

        public bool addOther(Client other)
        {
            if (this.other == null)
            {
                this.other = other;
                sendList();
                full = true;
                return true;
            }
            else
            {
                Console.WriteLine(other.NickName + " has tried to join " + creator.NickName + "'s Lobby but it's full!");
                other.Send(new ErrorMessagePacket("Lobby Is Full"));
                return false;
            }
        }

        public void sendList()
        {
            if (creator != null)
            {
                List<string> players = new List<string>();
                if (other == null)
                {
                    players.Add("Host> " + creator.NickName);
                    creator.Send(new LobbyPlayersPacket(players));
                }
                else
                {
                    players.Add("Host> " + creator.NickName);
                    players.Add(other.NickName);
                    creator.Send(new LobbyPlayersPacket(players));
                    other.Send(new LobbyPlayersPacket(players));
                }
                players.Clear();
            }
        }

        public void start()
        {
            if(creator != null && other != null)
            {
                creatorPick = string.Empty;
                otherPick = string.Empty;
                running = true;
                creator.Send(new StartPacket());
                other.Send(new StartPacket());
            }
        }
        public void setCreatorPick(string pick)
        {
            if (running == true)
            {
                creatorPick = pick;
                finishRound();
            }
        }
        public void setOtherPick(string pick)
        {
            if (running == true)
            {
                otherPick = pick;
                finishRound();
            }
        }

        public void finishRound()
        {

            if (!(creatorPick == null || creatorPick.Equals("") ) && !(otherPick == null || otherPick.Equals("")))
            {
                Console.WriteLine("round over");
                if (creatorPick.Equals("Rock") && otherPick.Equals("Scissors"))
                {
                    creator.Send(new WinnerPacket(1, otherPick));
                    other.Send(new WinnerPacket(0, creatorPick));
                }
                else if (creatorPick.Equals("Rock") && otherPick.Equals("Paper"))
                {
                    creator.Send(new WinnerPacket(0, otherPick));
                    other.Send(new WinnerPacket(1, creatorPick));
                }
                else if (creatorPick.Equals("Paper") && otherPick.Equals("Rock"))
                {
                    creator.Send(new WinnerPacket(1, otherPick));
                    other.Send(new WinnerPacket(0, creatorPick));
                }
                else if (creatorPick.Equals("Paper") && otherPick.Equals("Scissors"))
                {
                    creator.Send(new WinnerPacket(0, otherPick));
                    other.Send(new WinnerPacket(1, creatorPick));
                }
                else if (creatorPick.Equals("Scissors") && otherPick.Equals("Rock"))
                {
                    creator.Send(new WinnerPacket(0, otherPick));
                    other.Send(new WinnerPacket(1, creatorPick));
                }
                else if (creatorPick.Equals("Scissors") && otherPick.Equals("Paper"))
                {
                    creator.Send(new WinnerPacket(1, otherPick));
                    other.Send(new WinnerPacket(0, creatorPick));
                }
                else if(creatorPick.Equals(otherPick))
                {
                    Console.WriteLine("THIS IS A DRAW?");
                    creator.Send(new WinnerPacket(3, otherPick));
                    other.Send(new WinnerPacket(3, creatorPick));
                }
                else if(otherPick.Equals("FORFIT"))
                {
                    creator.Send(new WinnerPacket(1, "DIDN'T PICK"));
                    other.Send(new WinnerPacket(0, creatorPick));
                }
                else if (creatorPick.Equals("FORFIT"))
                {
                    creator.Send(new WinnerPacket(0, otherPick));
                    other.Send(new WinnerPacket(1, "DIDN'T PICK"));
                }
                else if (otherPick.Equals("FORFIT") && creatorPick.Equals("FORFIT"))
                {
                    creator.Send(new WinnerPacket(0, "DIDN'T PICK"));
                    other.Send(new WinnerPacket(0, "DIDN'T PICK"));
                }
                creatorPick = null;
                otherPick = null;
            }
        }

        public void forceQuit(Client client)
        {
            if (client.NickName.Equals(creator.NickName))
            {
                other.Send(new ForceQuitPacket());
                other.Send(new ErrorMessagePacket("Error> Other player left the game!"));
            }else
            {
                creator.Send(new ForceQuitPacket());
                creator.Send(new ErrorMessagePacket("Error> Other player left the game!"));
            }
        }








    }
}
