namespace Assignment2
{
    partial class DieGuessGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DieGuessGame));
            this.btnRoll = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pbDie = new System.Windows.Forms.PictureBox();
            this.lblTimesPlayed = new System.Windows.Forms.Label();
            this.lblTimesPlayedVal = new System.Windows.Forms.Label();
            this.lblTimesWon = new System.Windows.Forms.Label();
            this.lblTimesWonVal = new System.Windows.Forms.Label();
            this.lblTimesLost = new System.Windows.Forms.Label();
            this.lblTimesLostVal = new System.Windows.Forms.Label();
            this.gbGameInfo = new System.Windows.Forms.GroupBox();
            this.lblEnterGuess = new System.Windows.Forms.Label();
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.txtStats = new System.Windows.Forms.RichTextBox();
            this.lblInvalidInput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDie)).BeginInit();
            this.gbGameInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(364, 51);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 0;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(364, 86);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pbDie
            // 
            this.pbDie.Image = ((System.Drawing.Image)(resources.GetObject("pbDie.Image")));
            this.pbDie.Location = new System.Drawing.Point(279, 51);
            this.pbDie.Name = "pbDie";
            this.pbDie.Size = new System.Drawing.Size(58, 55);
            this.pbDie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDie.TabIndex = 2;
            this.pbDie.TabStop = false;
            // 
            // lblTimesPlayed
            // 
            this.lblTimesPlayed.AutoSize = true;
            this.lblTimesPlayed.Location = new System.Drawing.Point(5, 20);
            this.lblTimesPlayed.Name = "lblTimesPlayed";
            this.lblTimesPlayed.Size = new System.Drawing.Size(128, 13);
            this.lblTimesPlayed.TabIndex = 3;
            this.lblTimesPlayed.Text = "Number of Times Played: ";
            // 
            // lblTimesPlayedVal
            // 
            this.lblTimesPlayedVal.AutoSize = true;
            this.lblTimesPlayedVal.Location = new System.Drawing.Point(170, 20);
            this.lblTimesPlayedVal.Name = "lblTimesPlayedVal";
            this.lblTimesPlayedVal.Size = new System.Drawing.Size(13, 13);
            this.lblTimesPlayedVal.TabIndex = 4;
            this.lblTimesPlayedVal.Text = "0";
            // 
            // lblTimesWon
            // 
            this.lblTimesWon.AutoSize = true;
            this.lblTimesWon.Location = new System.Drawing.Point(5, 45);
            this.lblTimesWon.Name = "lblTimesWon";
            this.lblTimesWon.Size = new System.Drawing.Size(119, 13);
            this.lblTimesWon.TabIndex = 5;
            this.lblTimesWon.Text = "Number of Times Won: ";
            // 
            // lblTimesWonVal
            // 
            this.lblTimesWonVal.AutoSize = true;
            this.lblTimesWonVal.Location = new System.Drawing.Point(170, 45);
            this.lblTimesWonVal.Name = "lblTimesWonVal";
            this.lblTimesWonVal.Size = new System.Drawing.Size(13, 13);
            this.lblTimesWonVal.TabIndex = 6;
            this.lblTimesWonVal.Text = "0";
            // 
            // lblTimesLost
            // 
            this.lblTimesLost.AutoSize = true;
            this.lblTimesLost.Location = new System.Drawing.Point(5, 70);
            this.lblTimesLost.Name = "lblTimesLost";
            this.lblTimesLost.Size = new System.Drawing.Size(116, 13);
            this.lblTimesLost.TabIndex = 7;
            this.lblTimesLost.Text = "Number of Times Lost: ";
            // 
            // lblTimesLostVal
            // 
            this.lblTimesLostVal.AutoSize = true;
            this.lblTimesLostVal.Location = new System.Drawing.Point(170, 70);
            this.lblTimesLostVal.Name = "lblTimesLostVal";
            this.lblTimesLostVal.Size = new System.Drawing.Size(13, 13);
            this.lblTimesLostVal.TabIndex = 8;
            this.lblTimesLostVal.Text = "0";
            // 
            // gbGameInfo
            // 
            this.gbGameInfo.Controls.Add(this.lblTimesPlayed);
            this.gbGameInfo.Controls.Add(this.lblTimesLostVal);
            this.gbGameInfo.Controls.Add(this.lblTimesPlayedVal);
            this.gbGameInfo.Controls.Add(this.lblTimesWonVal);
            this.gbGameInfo.Controls.Add(this.lblTimesLost);
            this.gbGameInfo.Controls.Add(this.lblTimesWon);
            this.gbGameInfo.Location = new System.Drawing.Point(8, 12);
            this.gbGameInfo.Name = "gbGameInfo";
            this.gbGameInfo.Size = new System.Drawing.Size(200, 89);
            this.gbGameInfo.TabIndex = 9;
            this.gbGameInfo.TabStop = false;
            this.gbGameInfo.Text = "Game Info";
            // 
            // lblEnterGuess
            // 
            this.lblEnterGuess.AutoSize = true;
            this.lblEnterGuess.Location = new System.Drawing.Point(254, 14);
            this.lblEnterGuess.Name = "lblEnterGuess";
            this.lblEnterGuess.Size = new System.Drawing.Size(113, 13);
            this.lblEnterGuess.TabIndex = 10;
            this.lblEnterGuess.Text = "Enter your guess (1-6):";
            // 
            // txtGuess
            // 
            this.txtGuess.Location = new System.Drawing.Point(379, 11);
            this.txtGuess.MaxLength = 1;
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(27, 20);
            this.txtGuess.TabIndex = 11;
            // 
            // txtStats
            // 
            this.txtStats.Location = new System.Drawing.Point(8, 115);
            this.txtStats.Name = "txtStats";
            this.txtStats.Size = new System.Drawing.Size(467, 97);
            this.txtStats.TabIndex = 12;
            this.txtStats.Text = "FACE\tFREQUENCY\tPERCENT\tNUMBER OF TIMES GUESSED\n1\t0\t\t0.00%\t\t0\n2\t0\t\t0.00%\t\t0\n3\t0\t\t0" +
    ".00%\t\t0\n4\t0\t\t0.00%\t\t0\n5\t0\t\t0.00%\t\t0\n6\t0\t\t0.00%\t\t0";
            // 
            // lblInvalidInput
            // 
            this.lblInvalidInput.AutoSize = true;
            this.lblInvalidInput.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidInput.Location = new System.Drawing.Point(259, 34);
            this.lblInvalidInput.Name = "lblInvalidInput";
            this.lblInvalidInput.Size = new System.Drawing.Size(132, 13);
            this.lblInvalidInput.TabIndex = 13;
            this.lblInvalidInput.Text = "*Input an integer value 1-6";
            this.lblInvalidInput.Visible = false;
            // 
            // DieGuessGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 220);
            this.Controls.Add(this.lblInvalidInput);
            this.Controls.Add(this.txtStats);
            this.Controls.Add(this.txtGuess);
            this.Controls.Add(this.lblEnterGuess);
            this.Controls.Add(this.gbGameInfo);
            this.Controls.Add(this.pbDie);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRoll);
            this.Name = "DieGuessGame";
            this.Text = "Die Guess Game";
            ((System.ComponentModel.ISupportInitialize)(this.pbDie)).EndInit();
            this.gbGameInfo.ResumeLayout(false);
            this.gbGameInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pbDie;
        private System.Windows.Forms.Label lblTimesPlayed;
        private System.Windows.Forms.Label lblTimesPlayedVal;
        private System.Windows.Forms.Label lblTimesWon;
        private System.Windows.Forms.Label lblTimesWonVal;
        private System.Windows.Forms.Label lblTimesLost;
        private System.Windows.Forms.Label lblTimesLostVal;
        private System.Windows.Forms.GroupBox gbGameInfo;
        private System.Windows.Forms.Label lblEnterGuess;
        private System.Windows.Forms.TextBox txtGuess;
        private System.Windows.Forms.RichTextBox txtStats;
        private System.Windows.Forms.Label lblInvalidInput;
    }
}

