using Discord.Commands;
using System;
using System.Windows.Forms;

namespace DiscordBotManager.UI
{
    public partial class CommandConfigForm : Form
    {
        private CommandServiceConfig CSC;
        public CommandConfigForm(CommandServiceConfig currentCSC)
        {
            CSC = currentCSC;
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CommandServiceConfig _CommandServiceConfig = new CommandServiceConfig
            {
                CaseSensitiveCommands = caseCheck.Checked,
                IgnoreExtraArgs = ignoreChars.Checked
            };
            if (runModeAsync.Checked)
            {
                _CommandServiceConfig.DefaultRunMode = RunMode.Async;
            }
            else
            {
                _CommandServiceConfig.DefaultRunMode = RunMode.Sync;
            }
            if (logVerbose.Checked)
            {
                _CommandServiceConfig.LogLevel = Discord.LogSeverity.Verbose;
            }
            else
            {
                _CommandServiceConfig.LogLevel = Discord.LogSeverity.Warning;
            }
            Program.MainWindow.BOT.UpdateCommandConfig(_CommandServiceConfig);
        }

        private void CommandConfigForm_Load(object sender, EventArgs e)
        {
            caseCheck.Checked = CSC.CaseSensitiveCommands;
            logVerbose.Checked = CSC.LogLevel == Discord.LogSeverity.Verbose ? true : false;
            runModeAsync.Checked = CSC.DefaultRunMode == RunMode.Async ? true : false;
            ignoreChars.Checked = CSC.IgnoreExtraArgs;
        }
    }
}
