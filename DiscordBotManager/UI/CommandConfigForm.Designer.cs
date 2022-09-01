namespace DiscordBotManager.UI
{
    partial class CommandConfigForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.caseCheck = new System.Windows.Forms.CheckBox();
            this.runModeAsync = new System.Windows.Forms.CheckBox();
            this.logVerbose = new System.Windows.Forms.CheckBox();
            this.ignoreChars = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Discard";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // caseCheck
            // 
            this.caseCheck.AutoSize = true;
            this.caseCheck.Location = new System.Drawing.Point(7, 12);
            this.caseCheck.Name = "caseCheck";
            this.caseCheck.Size = new System.Drawing.Size(96, 17);
            this.caseCheck.TabIndex = 2;
            this.caseCheck.Text = "Case Sensitive";
            this.caseCheck.UseVisualStyleBackColor = true;
            // 
            // runModeAsync
            // 
            this.runModeAsync.AutoSize = true;
            this.runModeAsync.Location = new System.Drawing.Point(7, 35);
            this.runModeAsync.Name = "runModeAsync";
            this.runModeAsync.Size = new System.Drawing.Size(159, 17);
            this.runModeAsync.TabIndex = 3;
            this.runModeAsync.Text = "Run Async (Recommended)";
            this.runModeAsync.UseVisualStyleBackColor = true;
            // 
            // logVerbose
            // 
            this.logVerbose.AutoSize = true;
            this.logVerbose.Location = new System.Drawing.Point(7, 81);
            this.logVerbose.Name = "logVerbose";
            this.logVerbose.Size = new System.Drawing.Size(91, 17);
            this.logVerbose.TabIndex = 4;
            this.logVerbose.Text = "Verbose Logs";
            this.logVerbose.UseVisualStyleBackColor = true;
            // 
            // ignoreChars
            // 
            this.ignoreChars.AutoSize = true;
            this.ignoreChars.Location = new System.Drawing.Point(7, 58);
            this.ignoreChars.Name = "ignoreChars";
            this.ignoreChars.Size = new System.Drawing.Size(154, 17);
            this.ignoreChars.TabIndex = 5;
            this.ignoreChars.Text = "Ignore Extra Chars On Cmd";
            this.ignoreChars.UseVisualStyleBackColor = true;
            // 
            // CommandConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 138);
            this.Controls.Add(this.ignoreChars);
            this.Controls.Add(this.logVerbose);
            this.Controls.Add(this.runModeAsync);
            this.Controls.Add(this.caseCheck);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CommandConfigForm";
            this.Text = "Change Command Config";
            this.Load += new System.EventHandler(this.CommandConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox caseCheck;
        private System.Windows.Forms.CheckBox runModeAsync;
        private System.Windows.Forms.CheckBox logVerbose;
        private System.Windows.Forms.CheckBox ignoreChars;
    }
}