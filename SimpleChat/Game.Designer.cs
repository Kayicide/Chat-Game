namespace SimpleChat
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.RockButton = new System.Windows.Forms.Button();
            this.PaperButton = new System.Windows.Forms.Button();
            this.ScissorsButton = new System.Windows.Forms.Button();
            this.PickTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.countDownLabel = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.Player2 = new System.Windows.Forms.Label();
            this.RoundScoreLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.WinnerLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // RockButton
            // 
            this.RockButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.RockButton.Location = new System.Drawing.Point(12, 12);
            this.RockButton.Name = "RockButton";
            this.RockButton.Size = new System.Drawing.Size(213, 116);
            this.RockButton.TabIndex = 0;
            this.RockButton.Text = "Rock";
            this.RockButton.UseVisualStyleBackColor = true;
            this.RockButton.Click += new System.EventHandler(this.RockButton_Click);
            // 
            // PaperButton
            // 
            this.PaperButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.PaperButton.Location = new System.Drawing.Point(231, 12);
            this.PaperButton.Name = "PaperButton";
            this.PaperButton.Size = new System.Drawing.Size(213, 116);
            this.PaperButton.TabIndex = 1;
            this.PaperButton.Text = "Paper";
            this.PaperButton.UseVisualStyleBackColor = true;
            this.PaperButton.Click += new System.EventHandler(this.PaperButton_Click);
            // 
            // ScissorsButton
            // 
            this.ScissorsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.ScissorsButton.Location = new System.Drawing.Point(450, 12);
            this.ScissorsButton.Name = "ScissorsButton";
            this.ScissorsButton.Size = new System.Drawing.Size(213, 116);
            this.ScissorsButton.TabIndex = 2;
            this.ScissorsButton.Text = "Scissors";
            this.ScissorsButton.UseVisualStyleBackColor = true;
            this.ScissorsButton.Click += new System.EventHandler(this.ScissorsButton_Click);
            // 
            // PickTimer
            // 
            this.PickTimer.Interval = 1000;
            this.PickTimer.Tick += new System.EventHandler(this.PickTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(678, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Time Left";
            // 
            // countDownLabel
            // 
            this.countDownLabel.AutoSize = true;
            this.countDownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F);
            this.countDownLabel.Location = new System.Drawing.Point(678, 37);
            this.countDownLabel.Name = "countDownLabel";
            this.countDownLabel.Size = new System.Drawing.Size(127, 91);
            this.countDownLabel.TabIndex = 4;
            this.countDownLabel.Text = "10";
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Player1.Location = new System.Drawing.Point(12, 131);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(154, 25);
            this.Player1.TabIndex = 5;
            this.Player1.Text = "Player 1 Played:";
            // 
            // Player2
            // 
            this.Player2.AutoSize = true;
            this.Player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Player2.Location = new System.Drawing.Point(12, 173);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(154, 25);
            this.Player2.TabIndex = 6;
            this.Player2.Text = "Player 2 Played:";
            // 
            // RoundScoreLabel
            // 
            this.RoundScoreLabel.AutoSize = true;
            this.RoundScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.RoundScoreLabel.Location = new System.Drawing.Point(528, 122);
            this.RoundScoreLabel.Name = "RoundScoreLabel";
            this.RoundScoreLabel.Size = new System.Drawing.Size(52, 76);
            this.RoundScoreLabel.TabIndex = 8;
            this.RoundScoreLabel.Text = "/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "You/Opponent";
            // 
            // WinnerLabel
            // 
            this.WinnerLabel.AutoSize = true;
            this.WinnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.WinnerLabel.Location = new System.Drawing.Point(235, 218);
            this.WinnerLabel.Name = "WinnerLabel";
            this.WinnerLabel.Size = new System.Drawing.Size(209, 76);
            this.WinnerLabel.TabIndex = 10;
            this.WinnerLabel.Text = "label4";
            this.WinnerLabel.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(832, 293);
            this.Controls.Add(this.WinnerLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.countDownLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ScissorsButton);
            this.Controls.Add(this.PaperButton);
            this.Controls.Add(this.RockButton);
            this.Controls.Add(this.RoundScoreLabel);
            this.Name = "Game";
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RockButton;
        private System.Windows.Forms.Button PaperButton;
        private System.Windows.Forms.Button ScissorsButton;
        private System.Windows.Forms.Timer PickTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label countDownLabel;
        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.Label Player2;
        private System.Windows.Forms.Label RoundScoreLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label WinnerLabel;
        private System.Windows.Forms.Timer timer1;
    }
}