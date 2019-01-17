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
    public partial class WaitingLobby : Form
    {
        private BinaryFormatter formatter;
        private BinaryWriter writer;
        private List<string> inLobby;
        public Game game { get; private set; }
        private Boolean chat;

        public Form refToLobbyForm;
        public WaitingLobby(BinaryWriter writer, Form refToLobbyForm, Boolean chat)
        {
            this.chat = chat;
            this.refToLobbyForm = refToLobbyForm;
            //refToLobbyForm.Hide();
            InitializeComponent();
            this.writer = writer;
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

        private void WaitingLobby_Load(object sender, EventArgs e)
        {
            inLobby = new List<string>();
            //listBox1.DataSource = inLobby;
            formatter = new BinaryFormatter();
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            Send(new LeaveLobbyPacket());

            this.refToLobbyForm.Show();
            //Need to make sure the server knows the lobby will be disconnected from;
            this.Dispose();
        }

        private void WaitingLobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            Send(new LeaveLobbyPacket());


            DisconnectPacket packet = new DisconnectPacket();
            Send(packet);
        }

        private delegate void StringListVoidReturn(List<String> users);
        public void addUser(List<String> users)
        {
            if (InvokeRequired)
            {
                StringListVoidReturn del = new StringListVoidReturn(addUser);
                this.Invoke(del, new object[] { users });
            }
            else
            {
                LobbyUsernames.Items.Clear();
                Console.WriteLine("Trying to update people");
                foreach(string s in users)
                {
                    Console.WriteLine(s);
                    LobbyUsernames.Items.Add(s);
                }
                //listBox1.Items.Add()
                //inLobby = users;
                //listBox1.DataSource = null;
                //listBox1.DataSource = inLobby;
            }

        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            Send(new StartPacket());
        }

        public void start()
        {
            this.Invoke(new MethodInvoker(Application.OpenForms[0].Hide));
            this.Invoke(new MethodInvoker(this.Hide));
            this.Invoke(new MethodInvoker(this.load));
        }
        public void load()
        {
            game = new Game(writer, this);
            game.Show();
        }

        public void otherQuit()
        {
            this.Invoke(new MethodInvoker(this.refToLobbyForm.Show));
            this.Invoke(new MethodInvoker(this.game.Hide));
            this.Invoke(new MethodInvoker(this.game.Dispose));
            this.Invoke(new MethodInvoker(this.Dispose));
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
