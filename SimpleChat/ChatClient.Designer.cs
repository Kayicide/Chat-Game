namespace SimpleChat
{
    partial class ChatClient
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
            this.ChatWindow = new System.Windows.Forms.RichTextBox();
            this.Message = new System.Windows.Forms.RichTextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.OnlineUsers = new System.Windows.Forms.ListBox();
            this.ColorSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChatWindow
            // 
            this.ChatWindow.Location = new System.Drawing.Point(12, 12);
            this.ChatWindow.Name = "ChatWindow";
            this.ChatWindow.ReadOnly = true;
            this.ChatWindow.Size = new System.Drawing.Size(609, 364);
            this.ChatWindow.TabIndex = 0;
            this.ChatWindow.Text = "";
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(12, 382);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(609, 56);
            this.Message.TabIndex = 1;
            this.Message.Text = "";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(627, 411);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(160, 27);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // OnlineUsers
            // 
            this.OnlineUsers.FormattingEnabled = true;
            this.OnlineUsers.Location = new System.Drawing.Point(628, 38);
            this.OnlineUsers.Name = "OnlineUsers";
            this.OnlineUsers.Size = new System.Drawing.Size(160, 329);
            this.OnlineUsers.TabIndex = 4;
            // 
            // ColorSelector
            // 
            this.ColorSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorSelector.FormattingEnabled = true;
            this.ColorSelector.Location = new System.Drawing.Point(628, 382);
            this.ColorSelector.Name = "ColorSelector";
            this.ColorSelector.Size = new System.Drawing.Size(159, 21);
            this.ColorSelector.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(645, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Online Users";
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorSelector);
            this.Controls.Add(this.OnlineUsers);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.ChatWindow);
            this.Name = "ChatClient";
            this.Text = "Chat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatClient_FormClosing);
            this.Load += new System.EventHandler(this.ChatClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ChatWindow;
        private System.Windows.Forms.RichTextBox Message;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.ListBox OnlineUsers;
        private System.Windows.Forms.ComboBox ColorSelector;
        private System.Windows.Forms.Label label1;
    }
}