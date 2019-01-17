namespace SimpleChat
{
    partial class WaitingLobby
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
            this.LeaveButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.LobbyUsernames = new System.Windows.Forms.ListBox();
            this.ChatButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LeaveButton
            // 
            this.LeaveButton.Location = new System.Drawing.Point(12, 160);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(75, 23);
            this.LeaveButton.TabIndex = 0;
            this.LeaveButton.Text = "Leave";
            this.LeaveButton.UseVisualStyleBackColor = true;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 134);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LobbyUsernames
            // 
            this.LobbyUsernames.FormattingEnabled = true;
            this.LobbyUsernames.Location = new System.Drawing.Point(12, 12);
            this.LobbyUsernames.Name = "LobbyUsernames";
            this.LobbyUsernames.Size = new System.Drawing.Size(333, 121);
            this.LobbyUsernames.TabIndex = 2;
            // 
            // ChatButton
            // 
            this.ChatButton.Location = new System.Drawing.Point(296, 134);
            this.ChatButton.Name = "ChatButton";
            this.ChatButton.Size = new System.Drawing.Size(49, 49);
            this.ChatButton.TabIndex = 3;
            this.ChatButton.Text = "Chat";
            this.ChatButton.UseVisualStyleBackColor = true;
            this.ChatButton.Click += new System.EventHandler(this.ChatButton_Click);
            // 
            // WaitingLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 187);
            this.Controls.Add(this.ChatButton);
            this.Controls.Add(this.LobbyUsernames);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.LeaveButton);
            this.Name = "WaitingLobby";
            this.Text = "WaitingLobby";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WaitingLobby_FormClosing);
            this.Load += new System.EventHandler(this.WaitingLobby_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LeaveButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.ListBox LobbyUsernames;
        private System.Windows.Forms.Button ChatButton;
    }
}