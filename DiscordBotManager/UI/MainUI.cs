using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiscordBotManager.UI
{
    public partial class MainUI : Form
    {
        internal string _KEY = "None";
        public Bot.BotInstance BOT;
        public MainUI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Output To The UI Console
        /// </summary>
        /// <param name="Message">Message To Output</param>
        public void Output(string Message) => outputConsole.AppendText(String.Format("{0} > {1}", DateTime.Now, Message + Environment.NewLine));

        private void MainUI_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Output("Loaded UI...");
            Output("Creating Instace Of Bot");
            BOT = new Bot.BotInstance();
            Output("Created");
            CheckSavedKey();
        }

        /// <summary>
        /// Check And Reassign Loaded Key 
        /// </summary>
        private void CheckSavedKey()
        {
            Output("Checking for key...");
            if (System.IO.File.Exists(Program.TOKEN_PATH))
            {
                string contents = System.IO.File.ReadAllText(Program.TOKEN_PATH).Trim();
                if (!(string.IsNullOrWhiteSpace(contents)))
                {
                    _KEY = contents;
                    loadedKey.Text = _KEY;
                }
            }
        }

        private void NewkeyBtn_Click(object sender, EventArgs e)
        {
            AuthControls.NewKey form = new AuthControls.NewKey();
            form.ShowDialog();
            loadedKey.Text = _KEY;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_KEY))
            {
                Output("No Key Loaded");
                return;
            }
            _ = BOT.Login(_KEY);
        }

        /// <summary>
        /// Should be run to enable all controls only avalible when client is connected
        /// </summary>
        public void EnableControls()
        {
            cmdControls.Enabled = true;
        }
        /// <summary>
        /// Should be run to enable all controls only avalible when client is disconnected
        /// </summary>
        public void DisableControls()
        {
            cmdControls.Enabled = false;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            BOT.Logout();
        }

        private void OutputConsole_VisibleChanged(object sender, EventArgs e)
        {
            if (outputConsole.Visible)
            {
                outputConsole.SelectionStart = outputConsole.TextLength;
                outputConsole.ScrollToCaret();
            }
        }

        private void ShowKeyToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (showKeyToggle.Checked == false)
            {
                loadedKey.PasswordChar = '*';
            }
            else
            {
                loadedKey.PasswordChar = '\x0'; // empty
            }
        }

        private void ToggleAdmin(object sender, EventArgs e)
        {
            bool enabled = Bot.Commands.AdminModule.enabled;
            Bot.Commands.AdminModule.enabled = !enabled;

            if (enabled)
            {
                //its been disabled
                button2.ForeColor = Color.Red;
            }
            else
            {
                button2.ForeColor = Color.Green;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            bool enabled = Bot.Commands.UserModule.enabled;
            Bot.Commands.UserModule.enabled = !enabled;

            if (enabled)
            {
                //its been disabled
                button3.ForeColor = Color.Red;
            }
            else
            {
                button3.ForeColor = Color.Green;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            bool enabled = Bot.Commands.InfoModule.enabled;
            Bot.Commands.InfoModule.enabled = !enabled;

            if (enabled)
            {
                //its been disabled
                button4.ForeColor = Color.Red;
            }
            else
            {
                button4.ForeColor = Color.Green;
            }
        }

        private void EditCommandConfigWindow(object sender, EventArgs e)
        {

        }
    }
}
