namespace SimpleChat
{
    partial class Lobby
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.NicknameTextbox = new System.Windows.Forms.TextBox();
            this.CreateLobbyButton = new System.Windows.Forms.Button();
            this.JoinSelLobbyButton = new System.Windows.Forms.Button();
            this.LobbyList = new System.Windows.Forms.ListBox();
            this.SetNickname = new System.Windows.Forms.Button();
            this.ChatButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nickname:";
            // 
            // NicknameTextbox
            // 
            this.NicknameTextbox.Location = new System.Drawing.Point(80, 14);
            this.NicknameTextbox.Name = "NicknameTextbox";
            this.NicknameTextbox.Size = new System.Drawing.Size(215, 20);
            this.NicknameTextbox.TabIndex = 2;
            // 
            // CreateLobbyButton
            // 
            this.CreateLobbyButton.Location = new System.Drawing.Point(109, 323);
            this.CreateLobbyButton.Name = "CreateLobbyButton";
            this.CreateLobbyButton.Size = new System.Drawing.Size(101, 49);
            this.CreateLobbyButton.TabIndex = 3;
            this.CreateLobbyButton.Text = "Create Lobby";
            this.CreateLobbyButton.UseVisualStyleBackColor = true;
            this.CreateLobbyButton.Click += new System.EventHandler(this.CreateLobbyButton_Click);
            // 
            // JoinSelLobbyButton
            // 
            this.JoinSelLobbyButton.Location = new System.Drawing.Point(2, 323);
            this.JoinSelLobbyButton.Name = "JoinSelLobbyButton";
            this.JoinSelLobbyButton.Size = new System.Drawing.Size(101, 49);
            this.JoinSelLobbyButton.TabIndex = 4;
            this.JoinSelLobbyButton.Text = "Join Selected";
            this.JoinSelLobbyButton.UseVisualStyleBackColor = true;
            this.JoinSelLobbyButton.Click += new System.EventHandler(this.JoinSelLobbyButton_Click);
            // 
            // LobbyList
            // 
            this.LobbyList.FormattingEnabled = true;
            this.LobbyList.Location = new System.Drawing.Point(2, 40);
            this.LobbyList.Name = "LobbyList";
            this.LobbyList.Size = new System.Drawing.Size(390, 277);
            this.LobbyList.TabIndex = 6;
            // 
            // SetNickname
            // 
            this.SetNickname.Location = new System.Drawing.Point(301, 11);
            this.SetNickname.Name = "SetNickname";
            this.SetNickname.Size = new System.Drawing.Size(91, 23);
            this.SetNickname.TabIndex = 7;
            this.SetNickname.Text = "Set Nickname";
            this.SetNickname.UseVisualStyleBackColor = true;
            this.SetNickname.Click += new System.EventHandler(this.SetNickname_Click);
            // 
            // ChatButton
            // 
            this.ChatButton.Location = new System.Drawing.Point(291, 323);
            this.ChatButton.Name = "ChatButton";
            this.ChatButton.Size = new System.Drawing.Size(101, 49);
            this.ChatButton.TabIndex = 8;
            this.ChatButton.Text = "Chat";
            this.ChatButton.UseVisualStyleBackColor = true;
            this.ChatButton.Click += new System.EventHandler(this.ChatButton_Click);
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 378);
            this.Controls.Add(this.ChatButton);
            this.Controls.Add(this.SetNickname);
            this.Controls.Add(this.LobbyList);
            this.Controls.Add(this.JoinSelLobbyButton);
            this.Controls.Add(this.CreateLobbyButton);
            this.Controls.Add(this.NicknameTextbox);
            this.Controls.Add(this.label1);
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Lobby_FormClosing);
            this.Load += new System.EventHandler(this.Lobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NicknameTextbox;
        private System.Windows.Forms.Button CreateLobbyButton;
        private System.Windows.Forms.Button JoinSelLobbyButton;
        private System.Windows.Forms.ListBox LobbyList;
        private System.Windows.Forms.Button SetNickname;
        private System.Windows.Forms.Button ChatButton;
    }
}