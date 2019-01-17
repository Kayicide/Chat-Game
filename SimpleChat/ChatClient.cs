using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Packets;


namespace SimpleChat
{
    public partial class ChatClient : Form
    {

        private List<string> _onlineUsers;
        BinaryWriter writer;
        private BinaryFormatter formatter;
        public ChatClient(BinaryWriter writer)
        {
            InitializeComponent();
            this.writer = writer;
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Message.Text != String.Empty)
            {
                if (Message.Text.ToLower().Contains("!setnickname"))
                {
                    if (!(Message.Text.Length <= 12))
                    {
                        SetNickName(Message.Text.Substring(13));
                    }
                    else
                    {
                        UpdateChatWindow("Correct use: !setnickname (nickname)");
                    }
                }
                else
                {
                    switch (Message.Text)
                    {
                        default:
                            SendText(Message.Text, ColorSelector.Items[ColorSelector.SelectedIndex].ToString());
                            break;
                    }
                }
            }

            Message.Text = string.Empty;
        }

        private void SendText(string text, string color)
        {
            ChatMessagePacket message = new ChatMessagePacket(text, color);
            Console.WriteLine("Sent: " + message + "Color: " + color);
            Send(message);
        }
        public void SetNickName(string nickname)
        {
            NickNamePacket nicknamePacket = new NickNamePacket(nickname);
            Send(nicknamePacket);
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

        private void ChatClient_Load(object sender, EventArgs e)
        {
            _onlineUsers = new List<string>();
            OnlineUsers.DataSource = _onlineUsers;
            formatter = new BinaryFormatter();

            setupCombo();

        }

        private void setupCombo()
        {
            ColorSelector.Items.Add("Black");
            ColorSelector.Items.Add("Red");
            ColorSelector.Items.Add("Green");
            ColorSelector.Items.Add("Blue");

            ColorSelector.SelectedIndex = 0;
        }

        private delegate void StringVoidReturn(string value);
        private delegate void StringStringVoidReturn(string value, string Color);
        private delegate void StringListVoidReturn(List<string> value);
        public void UpdateChatWindow(string message)
        {
            if(InvokeRequired)
            {
                StringVoidReturn del = new StringVoidReturn(UpdateChatWindow);
                this.Invoke(del, new object[] { message });
            }
            else
            {
                ChatWindow.AppendText(message + "\n");
                ChatWindow.SelectionStart = ChatWindow.Text.Length;
                ChatWindow.ScrollToCaret();
                ChatWindow.SelectionColor = Color.Black;
            }
        }

        //Override for the colour selection, the main one being used.
        public void UpdateChatWindow(string message, String color)
        {
            if (InvokeRequired)
            {
                StringStringVoidReturn del = new StringStringVoidReturn(UpdateChatWindow);
                this.Invoke(del, new object[] { message, color });
            }
            else
            {

                Console.WriteLine("Reieved Messaged: " + message + "Color: " + color);

                ChatWindow.SelectionColor = Color.FromName(color);
                ChatWindow.AppendText(message + "\n");
                ChatWindow.SelectionStart = ChatWindow.Text.Length;
                ChatWindow.ScrollToCaret();
                ChatWindow.SelectionColor = Color.Black;
            }
        }

        public void addUserOnline(List<string> usernames)
        {
            if (InvokeRequired)
            {
                StringListVoidReturn del = new StringListVoidReturn(addUserOnline);
                this.Invoke(del, new object[] { usernames });
            }
            else
            {
                _onlineUsers = usernames;
                OnlineUsers.DataSource = null;
                OnlineUsers.DataSource = _onlineUsers;
            }

        }
        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

    }
}
