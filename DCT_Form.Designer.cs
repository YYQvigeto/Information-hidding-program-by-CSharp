
namespace 简单的信息隐藏程序
{
    partial class DCT_Form
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据库连接设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库连接设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.saveBox2 = new System.Windows.Forms.TextBox();
            this.openBox2 = new System.Windows.Forms.TextBox();
            this.openBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rateBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openBox4 = new System.Windows.Forms.TextBox();
            this.openBox3 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库连接设置ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(551, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据库连接设置ToolStripMenuItem
            // 
            this.数据库连接设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库连接设置ToolStripMenuItem1});
            this.数据库连接设置ToolStripMenuItem.Name = "数据库连接设置ToolStripMenuItem";
            this.数据库连接设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.数据库连接设置ToolStripMenuItem.Text = "设置";
            // 
            // 数据库连接设置ToolStripMenuItem1
            // 
            this.数据库连接设置ToolStripMenuItem1.Name = "数据库连接设置ToolStripMenuItem1";
            this.数据库连接设置ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.数据库连接设置ToolStripMenuItem1.Text = "数据库连接设置";
            this.数据库连接设置ToolStripMenuItem1.Click += new System.EventHandler(this.数据库连接设置ToolStripMenuItem1_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.saveBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 273);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "水印密钥证书生成";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(170, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 47);
            this.button2.TabIndex = 4;
            this.button2.Text = "生成密钥证书";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "证书内容输入：";
            // 
            // saveBox1
            // 
            this.saveBox1.Location = new System.Drawing.Point(107, 192);
            this.saveBox1.Name = "saveBox1";
            this.saveBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveBox1.Size = new System.Drawing.Size(304, 21);
            this.saveBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(168, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "选择证书保存地址";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 119);
            this.textBox1.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.saveBox2);
            this.groupBox2.Controls.Add(this.openBox2);
            this.groupBox2.Controls.Add(this.openBox1);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(13, 309);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(525, 270);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DCT水印嵌入";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(215, 100);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 48);
            this.button5.TabIndex = 7;
            this.button5.Text = "DCT嵌入";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // saveBox2
            // 
            this.saveBox2.Location = new System.Drawing.Point(318, 207);
            this.saveBox2.Name = "saveBox2";
            this.saveBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveBox2.Size = new System.Drawing.Size(199, 21);
            this.saveBox2.TabIndex = 6;
            // 
            // openBox2
            // 
            this.openBox2.Location = new System.Drawing.Point(7, 235);
            this.openBox2.Name = "openBox2";
            this.openBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openBox2.Size = new System.Drawing.Size(200, 21);
            this.openBox2.TabIndex = 5;
            // 
            // openBox1
            // 
            this.openBox1.Location = new System.Drawing.Point(6, 207);
            this.openBox1.Name = "openBox1";
            this.openBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openBox1.Size = new System.Drawing.Size(201, 21);
            this.openBox1.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(341, 178);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "选择保存地址";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(32, 177);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "选择载体图像和密钥证书";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(341, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 150);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(32, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 150);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.rateBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.openBox4);
            this.groupBox3.Controls.Add(this.openBox3);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Location = new System.Drawing.Point(13, 586);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(526, 272);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DCT水印检测";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(429, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "(%)";
            // 
            // rateBox
            // 
            this.rateBox.Location = new System.Drawing.Point(376, 120);
            this.rateBox.Name = "rateBox";
            this.rateBox.Size = new System.Drawing.Size(47, 21);
            this.rateBox.TabIndex = 7;
            this.rateBox.Text = "0";
            this.rateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "水印相似度：";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(205, 80);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 47);
            this.button7.TabIndex = 5;
            this.button7.Text = "DCT检测";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(323, 91);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(168, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 4;
            // 
            // openBox4
            // 
            this.openBox4.Location = new System.Drawing.Point(6, 233);
            this.openBox4.Name = "openBox4";
            this.openBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openBox4.Size = new System.Drawing.Size(200, 21);
            this.openBox4.TabIndex = 3;
            this.openBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // openBox3
            // 
            this.openBox3.Location = new System.Drawing.Point(7, 206);
            this.openBox3.Name = "openBox3";
            this.openBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openBox3.Size = new System.Drawing.Size(200, 21);
            this.openBox3.TabIndex = 2;
            this.openBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(32, 176);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "选择水印图像和密钥证书";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(32, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 150);
            this.panel3.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DCT_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 870);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DCT_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DCT_Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据库连接设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库连接设置ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox saveBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox saveBox2;
        private System.Windows.Forms.TextBox openBox2;
        private System.Windows.Forms.TextBox openBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox openBox4;
        private System.Windows.Forms.TextBox openBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox rateBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
    }
}