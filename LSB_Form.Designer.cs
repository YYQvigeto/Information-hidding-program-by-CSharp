
namespace 简单的信息隐藏程序
{
    partial class LSB_Form
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveBox2 = new System.Windows.Forms.TextBox();
            this.openBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.saveBox1 = new System.Windows.Forms.TextBox();
            this.openBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.saveBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.openBox4 = new System.Windows.Forms.TextBox();
            this.openBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveBox2);
            this.groupBox1.Controls.Add(this.openBox2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.saveBox1);
            this.groupBox1.Controls.Add(this.openBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 318);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LSB嵌入";
            // 
            // saveBox2
            // 
            this.saveBox2.Location = new System.Drawing.Point(391, 283);
            this.saveBox2.Name = "saveBox2";
            this.saveBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveBox2.Size = new System.Drawing.Size(275, 21);
            this.saveBox2.TabIndex = 13;
            // 
            // openBox2
            // 
            this.openBox2.Location = new System.Drawing.Point(6, 283);
            this.openBox2.Name = "openBox2";
            this.openBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openBox2.Size = new System.Drawing.Size(271, 21);
            this.openBox2.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.button3.Location = new System.Drawing.Point(276, 130);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "隐写===>";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "图层参数选择";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(293, 108);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(77, 16);
            this.radioButton3.TabIndex = 8;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "BLUE 图层";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(293, 85);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(77, 16);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "GREEN图层";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(293, 62);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 16);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "RED  图层";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // saveBox1
            // 
            this.saveBox1.Location = new System.Drawing.Point(391, 255);
            this.saveBox1.Name = "saveBox1";
            this.saveBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveBox1.Size = new System.Drawing.Size(275, 21);
            this.saveBox1.TabIndex = 5;
            // 
            // openBox1
            // 
            this.openBox1.Location = new System.Drawing.Point(6, 255);
            this.openBox1.Name = "openBox1";
            this.openBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openBox1.Size = new System.Drawing.Size(271, 21);
            this.openBox1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "保存地址and密钥保存地址";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "选择载体图片and选择秘密文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(431, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 200);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(33, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 200);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.saveBox3);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.openBox4);
            this.groupBox2.Controls.Add(this.openBox3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(12, 352);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 302);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LSB提取";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(431, 97);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "秘密信息保存地址";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // saveBox3
            // 
            this.saveBox3.Location = new System.Drawing.Point(397, 142);
            this.saveBox3.Name = "saveBox3";
            this.saveBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveBox3.Size = new System.Drawing.Size(275, 21);
            this.saveBox3.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(267, 92);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(127, 33);
            this.button5.TabIndex = 4;
            this.button5.Text = "提取==>";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // openBox4
            // 
            this.openBox4.Location = new System.Drawing.Point(6, 275);
            this.openBox4.Name = "openBox4";
            this.openBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openBox4.Size = new System.Drawing.Size(271, 21);
            this.openBox4.TabIndex = 3;
            // 
            // openBox3
            // 
            this.openBox3.Location = new System.Drawing.Point(6, 249);
            this.openBox3.Name = "openBox3";
            this.openBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.openBox3.Size = new System.Drawing.Size(271, 21);
            this.openBox3.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(39, 209);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(202, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "选择图片and选择密钥文件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(39, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(202, 174);
            this.panel3.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // LSB_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 667);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LSB_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox saveBox1;
        private System.Windows.Forms.TextBox openBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox openBox2;
        private System.Windows.Forms.TextBox saveBox2;
        private System.Windows.Forms.TextBox openBox4;
        private System.Windows.Forms.TextBox openBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox saveBox3;
        private System.Windows.Forms.Button button5;
    }
}