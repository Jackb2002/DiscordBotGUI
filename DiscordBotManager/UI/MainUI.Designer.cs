namespace DiscordBotManager.UI
{
    partial class MainUI
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
            this.outputConsole = new System.Windows.Forms.RichTextBox();
            this.authControls = new System.Windows.Forms.GroupBox();
            this.showKeyToggle = new System.Windows.Forms.CheckBox();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.newkeyBtn = new System.Windows.Forms.Button();
            this.keyLabel = new System.Windows.Forms.Label();
            this.loadedKey = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.cmdControls = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.authControls.SuspendLayout();
            this.cmdControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputConsole
            // 
            this.outputConsole.Location = new System.Drawing.Point(511, 12);
            this.outputConsole.Name = "outputConsole";
            this.outputConsole.ReadOnly = true;
            this.outputConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.outputConsole.Size = new System.Drawing.Size(277, 426);
            this.outputConsole.TabIndex = 0;
            this.outputConsole.Text = "";
            this.outputConsole.VisibleChanged += new System.EventHandler(this.OutputConsole_VisibleChanged);
            // 
            // authControls
            // 
            this.authControls.Controls.Add(this.showKeyToggle);
            this.authControls.Controls.Add(this.logoutBtn);
            this.authControls.Controls.Add(this.newkeyBtn);
            this.authControls.Controls.Add(this.keyLabel);
            this.authControls.Controls.Add(this.loadedKey);
            this.authControls.Controls.Add(this.loginBtn);
            this.authControls.Location = new System.Drawing.Point(12, 12);
            this.authControls.Name = "authControls";
            this.authControls.Size = new System.Drawing.Size(493, 79);
            this.authControls.TabIndex = 1;
            this.authControls.TabStop = false;
            this.authControls.Text = "Authentication";
            // 
            // showKeyToggle
            // 
            this.showKeyToggle.AutoSize = true;
            this.showKeyToggle.Location = new System.Drawing.Point(355, 30);
            this.showKeyToggle.Name = "showKeyToggle";
            this.showKeyToggle.Size = new System.Drawing.Size(74, 17);
            this.showKeyToggle.TabIndex = 9;
            this.showKeyToggle.Text = "Show Key";
            this.showKeyToggle.UseVisualStyleBackColor = true;
            this.showKeyToggle.CheckedChanged += new System.EventHandler(this.ShowKeyToggle_CheckedChanged);
            // 
            // logoutBtn
            // 
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft YaHei", 13F);
            this.logoutBtn.Location = new System.Drawing.Point(232, 19);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(101, 54);
            this.logoutBtn.TabIndex = 4;
            this.logoutBtn.Text = "Log Out";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // newkeyBtn
            // 
            this.newkeyBtn.Font = new System.Drawing.Font("Microsoft YaHei", 13F);
            this.newkeyBtn.Location = new System.Drawing.Point(119, 19);
            this.newkeyBtn.Name = "newkeyBtn";
            this.newkeyBtn.Size = new System.Drawing.Size(101, 54);
            this.newkeyBtn.TabIndex = 3;
            this.newkeyBtn.Text = "New Key";
            this.newkeyBtn.UseVisualStyleBackColor = true;
            this.newkeyBtn.Click += new System.EventHandler(this.NewkeyBtn_Click);
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.keyLabel.Location = new System.Drawing.Point(352, 13);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(77, 17);
            this.keyLabel.TabIndex = 2;
            this.keyLabel.Text = "Loaded Key";
            // 
            // loadedKey
            // 
            this.loadedKey.Location = new System.Drawing.Point(355, 53);
            this.loadedKey.Name = "loadedKey";
            this.loadedKey.PasswordChar = '*';
            this.loadedKey.ReadOnly = true;
            this.loadedKey.Size = new System.Drawing.Size(132, 20);
            this.loadedKey.TabIndex = 1;
            this.loadedKey.Text = "None";
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Microsoft YaHei", 13F);
            this.loginBtn.Location = new System.Drawing.Point(6, 19);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(101, 54);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.Text = "Log In ";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // cmdControls
            // 
            this.cmdControls.Controls.Add(this.button4);
            this.cmdControls.Controls.Add(this.button3);
            this.cmdControls.Controls.Add(this.button2);
            this.cmdControls.Controls.Add(this.button1);
            this.cmdControls.Enabled = false;
            this.cmdControls.Location = new System.Drawing.Point(12, 97);
            this.cmdControls.Name = "cmdControls";
            this.cmdControls.Size = new System.Drawing.Size(493, 101);
            this.cmdControls.TabIndex = 5;
            this.cmdControls.TabStop = false;
            this.cmdControls.Text = "Commands";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei", 8F);
            this.button4.ForeColor = System.Drawing.Color.Green;
            this.button4.Location = new System.Drawing.Point(384, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 54);
            this.button4.TabIndex = 8;
            this.button4.Text = "Toggle Info Module";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft YaHei", 8F);
            this.button3.ForeColor = System.Drawing.Color.Green;
            this.button3.Location = new System.Drawing.Point(258, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 54);
            this.button3.TabIndex = 7;
            this.button3.Text = "Toggle User Module";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 8F);
            this.button2.ForeColor = System.Drawing.Color.Green;
            this.button2.Location = new System.Drawing.Point(132, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 54);
            this.button2.TabIndex = 6;
            this.button2.Text = "Toggle Admin Module";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ToggleAdmin);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 8F);
            this.button1.Location = new System.Drawing.Point(6, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "Edit Command Config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EditCommandConfigWindow);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdControls);
            this.Controls.Add(this.authControls);
            this.Controls.Add(this.outputConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainUI";
            this.Text = "Discord Manager";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.authControls.ResumeLayout(false);
            this.authControls.PerformLayout();
            this.cmdControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox outputConsole;
        private System.Windows.Forms.GroupBox authControls;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.TextBox loadedKey;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Button newkeyBtn;
        private System.Windows.Forms.GroupBox cmdControls;
        private System.Windows.Forms.CheckBox showKeyToggle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}