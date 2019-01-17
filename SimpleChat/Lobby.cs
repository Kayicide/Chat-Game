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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleChat
{
    public partial class Lobby : Form
    {
        private BinaryFormatter formatter;
        private BinaryWriter writer;
        private List<String> lobbys;
        public WaitingLobby waitingLobby { get; set; }
        public Boolean chat {set; get; }

 
        public Lobby(BinaryWriter writer)
        {
            InitializeComponent();
            this.writer = writer;
            chat = false;
        }
        private void Send(Packet data)
        {
            MemoryStream mem = new MemoryStream();
            formatter.Serialize(mem, data);
            byte[] buffer = mem.GetBuffer();

            writer.Write(buffer.Length);
            writer.Write(buffer);
            writer.Flush();
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            lobbys = new List<string>();
            LobbyList.DataSource = lobbys;
            JoinSelLobbyButton.Enabled = false;
            CreateLobbyButton.Enabled = false;
            formatter = new BinaryFormatter();
        }

        private void Lobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisconnectPacket packet = new DisconnectPacket();
            Send(packet);
        }

        private void CreateLobbyButton_Click(object sender, EventArgs e)
        {
            if (NicknameTextbox.Text.Equals("") || NicknameTextbox.Text == string.Empty)
            {
            }
            else
            {
                waitingLobby = new WaitingLobby(writer, this, chat);
                Send(new CreateLobbyPacket(NicknameTextbox.Text));
                waitingLobby.Show();
                this.Hide();
            }
        }

        private delegate void StringListVoidReturn(List<String> creators);
        public void addLobbysOnline(List<String> creators)
        {
            if (InvokeRequired)
            {
                StringListVoidReturn del = new StringListVoidReturn(addLobbysOnline);
                this.Invoke(del, new object[] { creators });
            }
            else
            {
                lobbys = creators;
                LobbyList.DataSource = null;
                LobbyList.DataSource = lobbys;
            }

        }

        private void SetNickname_Click(object sender, EventArgs e)
        {
            if (!NicknameTextbox.Text.Equals(""))
            {
                Send(new NickNamePacket(NicknameTextbox.Text));
                JoinSelLobbyButton.Enabled = true;
                CreateLobbyButton.Enabled = true;
            }
        }

        private void JoinSelLobbyButton_Click(object sender, EventArgs e)
        {
            if (LobbyList.SelectedIndex != -1)
            {
                Send(new JoinLobbyPacket(LobbyList.GetItemText(LobbyList.SelectedItem)));
                waitingLobby = new WaitingLobby(writer, this, chat);
            }
        }

        public void joinSpaceAvailable()
        {
            Invoke(new MethodInvoker(waitingLobby.Show));
            Invoke(new MethodInvoker(this.Hide));
        }

        private void ChatButton_Click(object sender, EventArgs e)
        {
            if (chat == false)
            {
                Application.OpenForms[0].Show();
                chat = true;
            }
            else
            {
                Application.OpenForms[0].Hide();
                chat = false;
            }

        }
    }
}
