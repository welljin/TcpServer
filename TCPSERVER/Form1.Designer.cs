namespace TCPSERVER
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.IPcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PorttextBox = new System.Windows.Forms.TextBox();
            this.IPlistBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SendtextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ReceivetextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.LogtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(353, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Open";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // IPcomboBox
            // 
            this.IPcomboBox.FormattingEnabled = true;
            this.IPcomboBox.Location = new System.Drawing.Point(35, 8);
            this.IPcomboBox.Name = "IPcomboBox";
            this.IPcomboBox.Size = new System.Drawing.Size(121, 20);
            this.IPcomboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // PorttextBox
            // 
            this.PorttextBox.Location = new System.Drawing.Point(197, 8);
            this.PorttextBox.Name = "PorttextBox";
            this.PorttextBox.Size = new System.Drawing.Size(69, 21);
            this.PorttextBox.TabIndex = 5;
            this.PorttextBox.Text = "11000";
            this.PorttextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // IPlistBox
            // 
            this.IPlistBox.FormattingEnabled = true;
            this.IPlistBox.ItemHeight = 12;
            this.IPlistBox.Location = new System.Drawing.Point(4, 53);
            this.IPlistBox.Name = "IPlistBox";
            this.IPlistBox.Size = new System.Drawing.Size(120, 280);
            this.IPlistBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Clients";
            // 
            // SendtextBox
            // 
            this.SendtextBox.Location = new System.Drawing.Point(130, 53);
            this.SendtextBox.Multiline = true;
            this.SendtextBox.Name = "SendtextBox";
            this.SendtextBox.Size = new System.Drawing.Size(298, 119);
            this.SendtextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Receive Data";
            // 
            // ReceivetextBox
            // 
            this.ReceivetextBox.Location = new System.Drawing.Point(130, 199);
            this.ReceivetextBox.Multiline = true;
            this.ReceivetextBox.Name = "ReceivetextBox";
            this.ReceivetextBox.Size = new System.Drawing.Size(298, 134);
            this.ReceivetextBox.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(349, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // LogtextBox
            // 
            this.LogtextBox.Location = new System.Drawing.Point(4, 339);
            this.LogtextBox.Multiline = true;
            this.LogtextBox.Name = "LogtextBox";
            this.LogtextBox.Size = new System.Drawing.Size(424, 119);
            this.LogtextBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "Send Data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LogtextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ReceivetextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SendtextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IPlistBox);
            this.Controls.Add(this.PorttextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPcomboBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox IPcomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PorttextBox;
        private System.Windows.Forms.ListBox IPlistBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SendtextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ReceivetextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox LogtextBox;
        private System.Windows.Forms.Label label5;
    }
}

