namespace Assignment2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnRoll = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pbDie = new System.Windows.Forms.PictureBox();
            this.lblTimesPlayed = new System.Windows.Forms.Label();
            this.lblTimesPlayedVal = new System.Windows.Forms.Label();
            this.lblCorrectGuesses = new System.Windows.Forms.Label();
            this.lblCorrectGuessesVal = new System.Windows.Forms.Label();
            this.lblIncorrectGuesses = new System.Windows.Forms.Label();
            this.lblIncorrectGuessesVal = new System.Windows.Forms.Label();
            this.lblPercentangeTitle = new System.Windows.Forms.Label();
            this.gb1s = new System.Windows.Forms.GroupBox();
            this.lbl1Percentage = new System.Windows.Forms.Label();
            this.gb2s = new System.Windows.Forms.GroupBox();
            this.lbl2Percentage = new System.Windows.Forms.Label();
            this.gb4s = new System.Windows.Forms.GroupBox();
            this.lbl4Percentage = new System.Windows.Forms.Label();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.lbl3Percentage = new System.Windows.Forms.Label();
            this.gb6s = new System.Windows.Forms.GroupBox();
            this.lbl26ercentage = new System.Windows.Forms.Label();
            this.gb5 = new System.Windows.Forms.GroupBox();
            this.lbl5Percentage = new System.Windows.Forms.Label();
            this.lblNumberGuessedTitle = new System.Windows.Forms.Label();
            this.lbl1sGuessVal = new System.Windows.Forms.Label();
            this.gb1sGuess = new System.Windows.Forms.GroupBox();
            this.lbl2sGuessVal = new System.Windows.Forms.Label();
            this.gb2sGuess = new System.Windows.Forms.GroupBox();
            this.lbl3sGuessVal = new System.Windows.Forms.Label();
            this.gb3sGuess = new System.Windows.Forms.GroupBox();
            this.lbl4sGuessVal = new System.Windows.Forms.Label();
            this.gb4sGuess = new System.Windows.Forms.GroupBox();
            this.lbl5sGuessVal = new System.Windows.Forms.Label();
            this.gb5sGuess = new System.Windows.Forms.GroupBox();
            this.lbl6sGuessVal = new System.Windows.Forms.Label();
            this.gb6sGuess = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDie)).BeginInit();
            this.gb1s.SuspendLayout();
            this.gb2s.SuspendLayout();
            this.gb4s.SuspendLayout();
            this.gb3.SuspendLayout();
            this.gb6s.SuspendLayout();
            this.gb5.SuspendLayout();
            this.gb1sGuess.SuspendLayout();
            this.gb2sGuess.SuspendLayout();
            this.gb3sGuess.SuspendLayout();
            this.gb4sGuess.SuspendLayout();
            this.gb5sGuess.SuspendLayout();
            this.gb6sGuess.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(13, 226);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 0;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(95, 226);
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
            this.pbDie.Location = new System.Drawing.Point(214, 12);
            this.pbDie.Name = "pbDie";
            this.pbDie.Size = new System.Drawing.Size(58, 55);
            this.pbDie.TabIndex = 2;
            this.pbDie.TabStop = false;
            // 
            // lblTimesPlayed
            // 
            this.lblTimesPlayed.AutoSize = true;
            this.lblTimesPlayed.Location = new System.Drawing.Point(13, 13);
            this.lblTimesPlayed.Name = "lblTimesPlayed";
            this.lblTimesPlayed.Size = new System.Drawing.Size(128, 13);
            this.lblTimesPlayed.TabIndex = 3;
            this.lblTimesPlayed.Text = "Number of Times Played: ";
            // 
            // lblTimesPlayedVal
            // 
            this.lblTimesPlayedVal.AutoSize = true;
            this.lblTimesPlayedVal.Location = new System.Drawing.Point(148, 12);
            this.lblTimesPlayedVal.Name = "lblTimesPlayedVal";
            this.lblTimesPlayedVal.Size = new System.Drawing.Size(13, 13);
            this.lblTimesPlayedVal.TabIndex = 4;
            this.lblTimesPlayedVal.Text = "0";
            // 
            // lblCorrectGuesses
            // 
            this.lblCorrectGuesses.AutoSize = true;
            this.lblCorrectGuesses.Location = new System.Drawing.Point(13, 30);
            this.lblCorrectGuesses.Name = "lblCorrectGuesses";
            this.lblCorrectGuesses.Size = new System.Drawing.Size(89, 13);
            this.lblCorrectGuesses.TabIndex = 5;
            this.lblCorrectGuesses.Text = "Correct guesses: ";
            // 
            // lblCorrectGuessesVal
            // 
            this.lblCorrectGuessesVal.AutoSize = true;
            this.lblCorrectGuessesVal.Location = new System.Drawing.Point(148, 30);
            this.lblCorrectGuessesVal.Name = "lblCorrectGuessesVal";
            this.lblCorrectGuessesVal.Size = new System.Drawing.Size(13, 13);
            this.lblCorrectGuessesVal.TabIndex = 6;
            this.lblCorrectGuessesVal.Text = "0";
            // 
            // lblIncorrectGuesses
            // 
            this.lblIncorrectGuesses.AutoSize = true;
            this.lblIncorrectGuesses.Location = new System.Drawing.Point(13, 47);
            this.lblIncorrectGuesses.Name = "lblIncorrectGuesses";
            this.lblIncorrectGuesses.Size = new System.Drawing.Size(97, 13);
            this.lblIncorrectGuesses.TabIndex = 7;
            this.lblIncorrectGuesses.Text = "Incorrect guesses: ";
            // 
            // lblIncorrectGuessesVal
            // 
            this.lblIncorrectGuessesVal.AutoSize = true;
            this.lblIncorrectGuessesVal.Location = new System.Drawing.Point(148, 47);
            this.lblIncorrectGuessesVal.Name = "lblIncorrectGuessesVal";
            this.lblIncorrectGuessesVal.Size = new System.Drawing.Size(13, 13);
            this.lblIncorrectGuessesVal.TabIndex = 8;
            this.lblIncorrectGuessesVal.Text = "0";
            // 
            // lblPercentangeTitle
            // 
            this.lblPercentangeTitle.Location = new System.Drawing.Point(13, 71);
            this.lblPercentangeTitle.Name = "lblPercentangeTitle";
            this.lblPercentangeTitle.Size = new System.Drawing.Size(108, 27);
            this.lblPercentangeTitle.TabIndex = 9;
            this.lblPercentangeTitle.Text = "Percentage of times each number rolled";
            // 
            // gb1s
            // 
            this.gb1s.Controls.Add(this.lbl1Percentage);
            this.gb1s.Location = new System.Drawing.Point(16, 101);
            this.gb1s.Name = "gb1s";
            this.gb1s.Size = new System.Drawing.Size(35, 37);
            this.gb1s.TabIndex = 10;
            this.gb1s.TabStop = false;
            this.gb1s.Text = "1s";
            // 
            // lbl1Percentage
            // 
            this.lbl1Percentage.AutoSize = true;
            this.lbl1Percentage.Location = new System.Drawing.Point(7, 16);
            this.lbl1Percentage.Name = "lbl1Percentage";
            this.lbl1Percentage.Size = new System.Drawing.Size(21, 13);
            this.lbl1Percentage.TabIndex = 0;
            this.lbl1Percentage.Text = "0%";
            // 
            // gb2s
            // 
            this.gb2s.Controls.Add(this.lbl2Percentage);
            this.gb2s.Location = new System.Drawing.Point(57, 101);
            this.gb2s.Name = "gb2s";
            this.gb2s.Size = new System.Drawing.Size(35, 37);
            this.gb2s.TabIndex = 11;
            this.gb2s.TabStop = false;
            this.gb2s.Text = "2s";
            // 
            // lbl2Percentage
            // 
            this.lbl2Percentage.AutoSize = true;
            this.lbl2Percentage.Location = new System.Drawing.Point(6, 17);
            this.lbl2Percentage.Name = "lbl2Percentage";
            this.lbl2Percentage.Size = new System.Drawing.Size(21, 13);
            this.lbl2Percentage.TabIndex = 1;
            this.lbl2Percentage.Text = "0%";
            // 
            // gb4s
            // 
            this.gb4s.Controls.Add(this.lbl4Percentage);
            this.gb4s.Location = new System.Drawing.Point(57, 137);
            this.gb4s.Name = "gb4s";
            this.gb4s.Size = new System.Drawing.Size(35, 37);
            this.gb4s.TabIndex = 13;
            this.gb4s.TabStop = false;
            this.gb4s.Text = "4s";
            // 
            // lbl4Percentage
            // 
            this.lbl4Percentage.AutoSize = true;
            this.lbl4Percentage.Location = new System.Drawing.Point(6, 16);
            this.lbl4Percentage.Name = "lbl4Percentage";
            this.lbl4Percentage.Size = new System.Drawing.Size(21, 13);
            this.lbl4Percentage.TabIndex = 2;
            this.lbl4Percentage.Text = "0%";
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.lbl3Percentage);
            this.gb3.Location = new System.Drawing.Point(16, 137);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(35, 37);
            this.gb3.TabIndex = 12;
            this.gb3.TabStop = false;
            this.gb3.Text = "3s";
            // 
            // lbl3Percentage
            // 
            this.lbl3Percentage.AutoSize = true;
            this.lbl3Percentage.Location = new System.Drawing.Point(6, 16);
            this.lbl3Percentage.Name = "lbl3Percentage";
            this.lbl3Percentage.Size = new System.Drawing.Size(21, 13);
            this.lbl3Percentage.TabIndex = 3;
            this.lbl3Percentage.Text = "0%";
            // 
            // gb6s
            // 
            this.gb6s.Controls.Add(this.lbl26ercentage);
            this.gb6s.Location = new System.Drawing.Point(57, 174);
            this.gb6s.Name = "gb6s";
            this.gb6s.Size = new System.Drawing.Size(35, 37);
            this.gb6s.TabIndex = 15;
            this.gb6s.TabStop = false;
            this.gb6s.Text = "6s";
            // 
            // lbl26ercentage
            // 
            this.lbl26ercentage.AutoSize = true;
            this.lbl26ercentage.Location = new System.Drawing.Point(6, 16);
            this.lbl26ercentage.Name = "lbl26ercentage";
            this.lbl26ercentage.Size = new System.Drawing.Size(21, 13);
            this.lbl26ercentage.TabIndex = 16;
            this.lbl26ercentage.Text = "0%";
            // 
            // gb5
            // 
            this.gb5.Controls.Add(this.lbl5Percentage);
            this.gb5.Location = new System.Drawing.Point(16, 174);
            this.gb5.Name = "gb5";
            this.gb5.Size = new System.Drawing.Size(35, 37);
            this.gb5.TabIndex = 14;
            this.gb5.TabStop = false;
            this.gb5.Text = "5s";
            // 
            // lbl5Percentage
            // 
            this.lbl5Percentage.AutoSize = true;
            this.lbl5Percentage.Location = new System.Drawing.Point(6, 16);
            this.lbl5Percentage.Name = "lbl5Percentage";
            this.lbl5Percentage.Size = new System.Drawing.Size(21, 13);
            this.lbl5Percentage.TabIndex = 16;
            this.lbl5Percentage.Text = "0%";
            // 
            // lblNumberGuessedTitle
            // 
            this.lblNumberGuessedTitle.Location = new System.Drawing.Point(147, 71);
            this.lblNumberGuessedTitle.Name = "lblNumberGuessedTitle";
            this.lblNumberGuessedTitle.Size = new System.Drawing.Size(125, 27);
            this.lblNumberGuessedTitle.TabIndex = 16;
            this.lblNumberGuessedTitle.Text = "Number of times user guessed each number";
            // 
            // lbl1sGuessVal
            // 
            this.lbl1sGuessVal.AutoSize = true;
            this.lbl1sGuessVal.Location = new System.Drawing.Point(7, 16);
            this.lbl1sGuessVal.Name = "lbl1sGuessVal";
            this.lbl1sGuessVal.Size = new System.Drawing.Size(21, 13);
            this.lbl1sGuessVal.TabIndex = 0;
            this.lbl1sGuessVal.Text = "0%";
            // 
            // gb1sGuess
            // 
            this.gb1sGuess.Controls.Add(this.lbl1sGuessVal);
            this.gb1sGuess.Location = new System.Drawing.Point(150, 101);
            this.gb1sGuess.Name = "gb1sGuess";
            this.gb1sGuess.Size = new System.Drawing.Size(35, 37);
            this.gb1sGuess.TabIndex = 17;
            this.gb1sGuess.TabStop = false;
            this.gb1sGuess.Text = "1s";
            // 
            // lbl2sGuessVal
            // 
            this.lbl2sGuessVal.AutoSize = true;
            this.lbl2sGuessVal.Location = new System.Drawing.Point(6, 17);
            this.lbl2sGuessVal.Name = "lbl2sGuessVal";
            this.lbl2sGuessVal.Size = new System.Drawing.Size(21, 13);
            this.lbl2sGuessVal.TabIndex = 1;
            this.lbl2sGuessVal.Text = "0%";
            // 
            // gb2sGuess
            // 
            this.gb2sGuess.Controls.Add(this.lbl2sGuessVal);
            this.gb2sGuess.Location = new System.Drawing.Point(191, 101);
            this.gb2sGuess.Name = "gb2sGuess";
            this.gb2sGuess.Size = new System.Drawing.Size(35, 37);
            this.gb2sGuess.TabIndex = 18;
            this.gb2sGuess.TabStop = false;
            this.gb2sGuess.Text = "2s";
            // 
            // lbl3sGuessVal
            // 
            this.lbl3sGuessVal.AutoSize = true;
            this.lbl3sGuessVal.Location = new System.Drawing.Point(6, 16);
            this.lbl3sGuessVal.Name = "lbl3sGuessVal";
            this.lbl3sGuessVal.Size = new System.Drawing.Size(21, 13);
            this.lbl3sGuessVal.TabIndex = 3;
            this.lbl3sGuessVal.Text = "0%";
            // 
            // gb3sGuess
            // 
            this.gb3sGuess.Controls.Add(this.lbl3sGuessVal);
            this.gb3sGuess.Location = new System.Drawing.Point(150, 137);
            this.gb3sGuess.Name = "gb3sGuess";
            this.gb3sGuess.Size = new System.Drawing.Size(35, 37);
            this.gb3sGuess.TabIndex = 19;
            this.gb3sGuess.TabStop = false;
            this.gb3sGuess.Text = "3s";
            // 
            // lbl4sGuessVal
            // 
            this.lbl4sGuessVal.AutoSize = true;
            this.lbl4sGuessVal.Location = new System.Drawing.Point(6, 16);
            this.lbl4sGuessVal.Name = "lbl4sGuessVal";
            this.lbl4sGuessVal.Size = new System.Drawing.Size(21, 13);
            this.lbl4sGuessVal.TabIndex = 2;
            this.lbl4sGuessVal.Text = "0%";
            // 
            // gb4sGuess
            // 
            this.gb4sGuess.Controls.Add(this.lbl4sGuessVal);
            this.gb4sGuess.Location = new System.Drawing.Point(191, 137);
            this.gb4sGuess.Name = "gb4sGuess";
            this.gb4sGuess.Size = new System.Drawing.Size(35, 37);
            this.gb4sGuess.TabIndex = 20;
            this.gb4sGuess.TabStop = false;
            this.gb4sGuess.Text = "4s";
            // 
            // lbl5sGuessVal
            // 
            this.lbl5sGuessVal.AutoSize = true;
            this.lbl5sGuessVal.Location = new System.Drawing.Point(6, 16);
            this.lbl5sGuessVal.Name = "lbl5sGuessVal";
            this.lbl5sGuessVal.Size = new System.Drawing.Size(21, 13);
            this.lbl5sGuessVal.TabIndex = 16;
            this.lbl5sGuessVal.Text = "0%";
            // 
            // gb5sGuess
            // 
            this.gb5sGuess.Controls.Add(this.lbl5sGuessVal);
            this.gb5sGuess.Location = new System.Drawing.Point(150, 174);
            this.gb5sGuess.Name = "gb5sGuess";
            this.gb5sGuess.Size = new System.Drawing.Size(35, 37);
            this.gb5sGuess.TabIndex = 21;
            this.gb5sGuess.TabStop = false;
            this.gb5sGuess.Text = "5s";
            // 
            // lbl6sGuessVal
            // 
            this.lbl6sGuessVal.AutoSize = true;
            this.lbl6sGuessVal.Location = new System.Drawing.Point(6, 16);
            this.lbl6sGuessVal.Name = "lbl6sGuessVal";
            this.lbl6sGuessVal.Size = new System.Drawing.Size(21, 13);
            this.lbl6sGuessVal.TabIndex = 16;
            this.lbl6sGuessVal.Text = "0%";
            // 
            // gb6sGuess
            // 
            this.gb6sGuess.Controls.Add(this.lbl6sGuessVal);
            this.gb6sGuess.Location = new System.Drawing.Point(191, 174);
            this.gb6sGuess.Name = "gb6sGuess";
            this.gb6sGuess.Size = new System.Drawing.Size(35, 37);
            this.gb6sGuess.TabIndex = 22;
            this.gb6sGuess.TabStop = false;
            this.gb6sGuess.Text = "6s";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblNumberGuessedTitle);
            this.Controls.Add(this.gb1sGuess);
            this.Controls.Add(this.gb2sGuess);
            this.Controls.Add(this.gb3sGuess);
            this.Controls.Add(this.gb4sGuess);
            this.Controls.Add(this.gb5sGuess);
            this.Controls.Add(this.gb6sGuess);
            this.Controls.Add(this.gb6s);
            this.Controls.Add(this.gb4s);
            this.Controls.Add(this.gb5);
            this.Controls.Add(this.gb2s);
            this.Controls.Add(this.gb3);
            this.Controls.Add(this.gb1s);
            this.Controls.Add(this.lblPercentangeTitle);
            this.Controls.Add(this.lblIncorrectGuessesVal);
            this.Controls.Add(this.lblIncorrectGuesses);
            this.Controls.Add(this.lblCorrectGuessesVal);
            this.Controls.Add(this.lblCorrectGuesses);
            this.Controls.Add(this.lblTimesPlayedVal);
            this.Controls.Add(this.lblTimesPlayed);
            this.Controls.Add(this.pbDie);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRoll);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbDie)).EndInit();
            this.gb1s.ResumeLayout(false);
            this.gb1s.PerformLayout();
            this.gb2s.ResumeLayout(false);
            this.gb2s.PerformLayout();
            this.gb4s.ResumeLayout(false);
            this.gb4s.PerformLayout();
            this.gb3.ResumeLayout(false);
            this.gb3.PerformLayout();
            this.gb6s.ResumeLayout(false);
            this.gb6s.PerformLayout();
            this.gb5.ResumeLayout(false);
            this.gb5.PerformLayout();
            this.gb1sGuess.ResumeLayout(false);
            this.gb1sGuess.PerformLayout();
            this.gb2sGuess.ResumeLayout(false);
            this.gb2sGuess.PerformLayout();
            this.gb3sGuess.ResumeLayout(false);
            this.gb3sGuess.PerformLayout();
            this.gb4sGuess.ResumeLayout(false);
            this.gb4sGuess.PerformLayout();
            this.gb5sGuess.ResumeLayout(false);
            this.gb5sGuess.PerformLayout();
            this.gb6sGuess.ResumeLayout(false);
            this.gb6sGuess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pbDie;
        private System.Windows.Forms.Label lblTimesPlayed;
        private System.Windows.Forms.Label lblTimesPlayedVal;
        private System.Windows.Forms.Label lblCorrectGuesses;
        private System.Windows.Forms.Label lblCorrectGuessesVal;
        private System.Windows.Forms.Label lblIncorrectGuesses;
        private System.Windows.Forms.Label lblIncorrectGuessesVal;
        private System.Windows.Forms.Label lblPercentangeTitle;
        private System.Windows.Forms.GroupBox gb1s;
        private System.Windows.Forms.Label lbl1Percentage;
        private System.Windows.Forms.GroupBox gb2s;
        private System.Windows.Forms.Label lbl2Percentage;
        private System.Windows.Forms.GroupBox gb4s;
        private System.Windows.Forms.Label lbl4Percentage;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.Label lbl3Percentage;
        private System.Windows.Forms.GroupBox gb6s;
        private System.Windows.Forms.Label lbl26ercentage;
        private System.Windows.Forms.GroupBox gb5;
        private System.Windows.Forms.Label lbl5Percentage;
        private System.Windows.Forms.Label lblNumberGuessedTitle;
        private System.Windows.Forms.Label lbl1sGuessVal;
        private System.Windows.Forms.GroupBox gb1sGuess;
        private System.Windows.Forms.Label lbl2sGuessVal;
        private System.Windows.Forms.GroupBox gb2sGuess;
        private System.Windows.Forms.Label lbl3sGuessVal;
        private System.Windows.Forms.GroupBox gb3sGuess;
        private System.Windows.Forms.Label lbl4sGuessVal;
        private System.Windows.Forms.GroupBox gb4sGuess;
        private System.Windows.Forms.Label lbl5sGuessVal;
        private System.Windows.Forms.GroupBox gb5sGuess;
        private System.Windows.Forms.Label lbl6sGuessVal;
        private System.Windows.Forms.GroupBox gb6sGuess;
    }
}

