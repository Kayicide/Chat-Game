using Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleChat
{
    public partial class Game : Form
    {
        private BinaryFormatter formatter;
        private BinaryWriter writer;
        private int timeLeft;
        private int round;
        private int player1score;
        private int player2score;
        private string Selection = string.Empty;
        private string otherSelection = string.Empty;
        private WaitingLobby refToLobby;
        private int roundWinner { set; get; } = -1; //1 = won, 0 = losser, 3 = draw,  -1 = not set.

        public Game(BinaryWriter writer, WaitingLobby refToLobby)
        {
            InitializeComponent();
            this.writer = writer;
            this.refToLobby = refToLobby;
        }
        private void Send(Packet data)
        {
            Console.WriteLine("sent packet");
            MemoryStream mem = new MemoryStream();
            formatter.Serialize(mem, data);
            byte[] buffer = mem.GetBuffer();

            writer.Write(buffer.Length);
            writer.Write(buffer);
            writer.Flush();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            formatter = new BinaryFormatter();
            timeLeft = 10;
            round = 1;
            PickTimer.Start();
        }

        private void PickTimer_Tick(object sender, EventArgs e)
        {
            if(timeLeft >= 0)
            {
                countDownLabel.Text = timeLeft.ToString();
                timeLeft = timeLeft - 1;
            }else
            {
                if (round <= 3)
                {
                    if (Selection == string.Empty || Selection == null)
                    {
                        Send(new OptionPickPacket("FORFIT"));
                    }
                    else
                    {
                        Send(new OptionPickPacket(Selection));
                    }
 
                    SpinWait.SpinUntil(() => roundWait() == true);
                    upScores();
                    Player1.Text = "You played: " + Selection;
                    Player2.Text = "Opponent played: " + otherSelection;
                    timeLeft = 10;
                    if (round == 3)
                    {
                        Finish();
                    }
                    round = round + 1;
                }
            }
        }

        private Boolean roundWait()
        {
            if (roundWinner < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void RockButton_Click(object sender, EventArgs e)
        {
            PaperButton.Enabled = true;
            ScissorsButton.Enabled = true;
            RockButton.Enabled = false;
            Selection = "Rock";
        }

        private void PaperButton_Click(object sender, EventArgs e)
        {
            ScissorsButton.Enabled = true;
            RockButton.Enabled = true;
            PaperButton.Enabled = false;
            Selection = "Paper";
        }

        private void ScissorsButton_Click(object sender, EventArgs e)
        {
            RockButton.Enabled = true;
            PaperButton.Enabled = true;
            ScissorsButton.Enabled = false;
            Selection = "Scissors";
        }

        public void upScores()
        {
            Console.WriteLine("UPDATING SCORES");
            if (roundWinner == 1)
            {
                player1score++;
            }
            else if (roundWinner == 0)
            {
                player2score++;
            }
            else
            {
                player1score++;
                player2score++;
            }
            RoundScoreLabel.Text = (player1score + "/" + player2score);
            roundWinner = -1;
        }

        public void winnerPacket(int i, string other)
        {
            roundWinner = i;
            otherSelection = other;
        }

        private void Finish()
        {
            PickTimer.Stop();
            if (player1score > player2score)
            {
                WinnerLabel.Text = "You Win!";
                WinnerLabel.Visible = true;
            }
            else
            {
                WinnerLabel.Text = "You Loose!";
                WinnerLabel.Visible = true;
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refToLobby.Show();
            this.Dispose();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            Send(new ForceQuitPacket());
            Send(new DisconnectPacket());
        }
    }
}
