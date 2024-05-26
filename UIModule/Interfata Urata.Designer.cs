namespace UIModule
{
    partial class InterfataSimpla
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextFurat = new System.Windows.Forms.TextBox();
            this.Exit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ModAfisare = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SocketDebug = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.ButonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text Furat";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TextFurat
            // 
            this.TextFurat.Location = new System.Drawing.Point(22, 183);
            this.TextFurat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextFurat.Multiline = true;
            this.TextFurat.Name = "TextFurat";
            this.TextFurat.Size = new System.Drawing.Size(1164, 452);
            this.TextFurat.TabIndex = 2;
            this.TextFurat.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(448, 646);
            this.Exit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(150, 46);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Help";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(609, 646);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 46);
            this.button2.TabIndex = 4;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ModAfisare
            // 
            this.ModAfisare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModAfisare.FormattingEnabled = true;
            this.ModAfisare.Items.AddRange(new object[] {
            "Hex",
            "String",
            "Char",
            "Smart"});
            this.ModAfisare.Location = new System.Drawing.Point(126, 43);
            this.ModAfisare.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ModAfisare.Name = "ModAfisare";
            this.ModAfisare.Size = new System.Drawing.Size(180, 28);
            this.ModAfisare.TabIndex = 8;
            this.ModAfisare.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.ModAfisare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ModAfisare_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Mod Afisare:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SocketDebug
            // 
            this.SocketDebug.Location = new System.Drawing.Point(22, 108);
            this.SocketDebug.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SocketDebug.Multiline = true;
            this.SocketDebug.Name = "SocketDebug";
            this.SocketDebug.Size = new System.Drawing.Size(1164, 27);
            this.SocketDebug.TabIndex = 10;
            this.SocketDebug.TextChanged += new System.EventHandler(this.SocketDebug_TextChanged);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "E:\\PROIECT IP\\Interfata Urata\\res\\Key Logger.chm";
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "E:\\PROIECT IP\\Interfata Urata\\res\\Key Logger.chm";
            // 
            // ButonClear
            // 
            this.ButonClear.Location = new System.Drawing.Point(314, 43);
            this.ButonClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButonClear.Name = "ButonClear";
            this.ButonClear.Size = new System.Drawing.Size(113, 28);
            this.ButonClear.TabIndex = 11;
            this.ButonClear.Text = "Clear";
            this.ButonClear.UseVisualStyleBackColor = true;
            this.ButonClear.Click += new System.EventHandler(this.ButonClear_Click);
            // 
            // InterfataSimpla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 709);
            this.Controls.Add(this.ButonClear);
            this.Controls.Add(this.SocketDebug);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ModAfisare);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.TextFurat);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InterfataSimpla";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Capture";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox TextFurat;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox ModAfisare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox SocketDebug;
        private System.Windows.Forms.Button ButonClear;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

