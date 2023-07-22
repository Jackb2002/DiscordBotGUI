using System;
using System.Windows.Forms;

namespace DiscordBotManager.UI
{
    public partial class MainUI : Form
    {
        internal string _KEY = "";
        internal string _FLAKE = "";
        public Bot.BotInstance BOT;
        public MainUI()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Output To The UI Console
        /// </summary>
        /// <param name="Message">Message To Output</param>
        public void Output(string Message)
        {
            outputConsole.AppendText(string.Format("{0} > {1}", DateTime.Now, Message + Environment.NewLine));
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Output("Loaded UI...");
            Output("Creating Instace Of Bot");
            BOT = new Bot.BotInstance(_FLAKE);
            Output("Created");
            CheckSavedKeys();
            Output("Attempting auto-login");
            LoginBtn_Click(sender, e);
        }

        /// <summary>
        /// Check And Reassign Loaded Key 
        /// </summary>
        private void CheckSavedKeys()
        {
            Output("Checking for keys...");
            //CHECK FOR TOKEN
            if (System.IO.File.Exists(Program.TOKEN_PATH))
            {
                string contents = System.IO.File.ReadAllText(Program.TOKEN_PATH).Trim();
                if (!string.IsNullOrWhiteSpace(contents))
                {
                    Output("Found key");
                    _KEY = contents;
                    loadedKey.Text = _KEY;
                }
            }
            //CHECK FOR SNOWFLAKE
            if (System.IO.File.Exists(Program.FLAKE_PATH))
            {
                string contents = System.IO.File.ReadAllText(Program.FLAKE_PATH).Trim();
                if (!string.IsNullOrWhiteSpace(contents))
                {
                    Output("Found Snowflake");
                    _FLAKE = contents;
                }
            }
        }

        private void NewkeyBtn_Click(object sender, EventArgs e)
        {
            AuthControls.NewKey form = new AuthControls.NewKey();
            _ = form.ShowDialog();
            loadedKey.Text = _KEY;
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_KEY))
            {
                Output("No Key Loaded");
                return;
            }
            if (BOT._client.LoginState == Discord.LoginState.LoggingIn
                || BOT._client.LoginState == Discord.LoginState.LoggedIn)
            {
                Output("Already logging/logged in");
                return;
            }
            Output("Logging in with key");
            _ = BOT.Login(_KEY);
        }

        /// <summary>
        /// Should be run to enable all controls only avalible when client is connected
        /// </summary>
        public void EnableConnectedOnlyControls()
        {

        }
        /// <summary>
        /// Should be run to enable all controls only avalible when client is disconnected
        /// </summary>
        public void DisableConnectedOnlyControls()
        {

        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Output("Logging out");
            BOT.Logout().GetAwaiter().GetResult();
            Output("Logged out");
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
        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BOT._client.LoginState == Discord.LoginState.LoggedIn)
            {
                Output("Unable to close, still logged in");
                e.Cancel = true;
                return;
            }
        }

        private void addCustomFlake_Click(object sender, EventArgs e)
        {
            AuthControls.NewSnowflake form = new AuthControls.NewSnowflake();
            _ = form.ShowDialog();
        }
    }
}
