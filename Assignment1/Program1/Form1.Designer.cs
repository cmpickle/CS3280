namespace Program1
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
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.txtBox2 = new System.Windows.Forms.TextBox();
            this.txtBox3 = new System.Windows.Forms.TextBox();
            this.btnSubmit1 = new System.Windows.Forms.Button();
            this.btnSubmit2 = new System.Windows.Forms.Button();
            this.btnSubmit3 = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gb2 = new System.Windows.Forms.GroupBox();
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gb1.SuspendLayout();
            this.gb2.SuspendLayout();
            this.gb3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBox1
            // 
            this.txtBox1.Location = new System.Drawing.Point(6, 19);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(100, 20);
            this.txtBox1.TabIndex = 0;
            // 
            // txtBox2
            // 
            this.txtBox2.Location = new System.Drawing.Point(6, 19);
            this.txtBox2.Name = "txtBox2";
            this.txtBox2.Size = new System.Drawing.Size(100, 20);
            this.txtBox2.TabIndex = 1;
            // 
            // txtBox3
            // 
            this.txtBox3.Location = new System.Drawing.Point(6, 19);
            this.txtBox3.Name = "txtBox3";
            this.txtBox3.Size = new System.Drawing.Size(100, 20);
            this.txtBox3.TabIndex = 2;
            // 
            // btnSubmit1
            // 
            this.btnSubmit1.Location = new System.Drawing.Point(6, 45);
            this.btnSubmit1.Name = "btnSubmit1";
            this.btnSubmit1.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit1.TabIndex = 3;
            this.btnSubmit1.Text = "submit";
            this.btnSubmit1.UseVisualStyleBackColor = true;
            this.btnSubmit1.Click += new System.EventHandler(this.btnSubmit1_Click);
            // 
            // btnSubmit2
            // 
            this.btnSubmit2.Location = new System.Drawing.Point(6, 45);
            this.btnSubmit2.Name = "btnSubmit2";
            this.btnSubmit2.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit2.TabIndex = 4;
            this.btnSubmit2.Text = "submit";
            this.btnSubmit2.UseVisualStyleBackColor = true;
            this.btnSubmit2.Click += new System.EventHandler(this.btnSubmit2_Click);
            // 
            // btnSubmit3
            // 
            this.btnSubmit3.Location = new System.Drawing.Point(6, 45);
            this.btnSubmit3.Name = "btnSubmit3";
            this.btnSubmit3.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit3.TabIndex = 5;
            this.btnSubmit3.Text = "submit";
            this.btnSubmit3.UseVisualStyleBackColor = true;
            this.btnSubmit3.Click += new System.EventHandler(this.btnSubmit3_Click);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.txtBox1);
            this.gb1.Controls.Add(this.btnSubmit1);
            this.gb1.Location = new System.Drawing.Point(12, 12);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(123, 172);
            this.gb1.TabIndex = 6;
            this.gb1.TabStop = false;
            this.gb1.Text = "OK";
            // 
            // gb2
            // 
            this.gb2.Controls.Add(this.label2);
            this.gb2.Controls.Add(this.txtBox2);
            this.gb2.Controls.Add(this.btnSubmit2);
            this.gb2.Location = new System.Drawing.Point(154, 12);
            this.gb2.Name = "gb2";
            this.gb2.Size = new System.Drawing.Size(123, 172);
            this.gb2.TabIndex = 7;
            this.gb2.TabStop = false;
            this.gb2.Text = "OK, CANCEL";
            // 
            // gb3
            // 
            this.gb3.Controls.Add(this.label3);
            this.gb3.Controls.Add(this.txtBox3);
            this.gb3.Controls.Add(this.btnSubmit3);
            this.gb3.Location = new System.Drawing.Point(291, 12);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(126, 172);
            this.gb3.TabIndex = 8;
            this.gb3.TabStop = false;
            this.gb3.Text = "YES, NO";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(157, 196);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 9;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 79);
            this.label1.TabIndex = 4;
            this.label1.Text = "If you select this button a MessageBox will display your message along with an OK" +
    " button and an Information icon";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 93);
            this.label2.TabIndex = 5;
            this.label2.Text = "If you select this button a MessageBox will display your message along with OK an" +
    "d CANCEL buttons and a Warning icon";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 79);
            this.label3.TabIndex = 6;
            this.label3.Text = "If you select this button a MessageBox will display your message along with YES a" +
    "nd NO buttons and a Error icon";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 223);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.gb3);
            this.Controls.Add(this.gb2);
            this.Controls.Add(this.gb1);
            this.Name = "Form1";
            this.Text = "Program 1";
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gb2.ResumeLayout(false);
            this.gb2.PerformLayout();
            this.gb3.ResumeLayout(false);
            this.gb3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox1;
        private System.Windows.Forms.TextBox txtBox2;
        private System.Windows.Forms.TextBox txtBox3;
        private System.Windows.Forms.Button btnSubmit1;
        private System.Windows.Forms.Button btnSubmit2;
        private System.Windows.Forms.Button btnSubmit3;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.GroupBox gb2;
        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

