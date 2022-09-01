using Discord.Commands;
using System;
using System.Windows.Forms;

namespace DiscordBotManager.UI
{
    public partial class CommandConfigForm : Form
    {
        private readonly CommandServiceConfig CSC;
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
                IgnoreExtraArgs = ignoreChars.Checked,
                DefaultRunMode = runModeAsync.Checked ? RunMode.Async : RunMode.Sync,
                LogLevel = logVerbose.Checked ? Discord.LogSeverity.Verbose : Discord.LogSeverity.Warning
            };
            Program.MainWindow.BOT.UpdateCommandConfig(_CommandServiceConfig);
        }

        private void CommandConfigForm_Load(object sender, EventArgs e)
        {
            caseCheck.Checked = CSC.CaseSensitiveCommands;
            logVerbose.Checked = CSC.LogLevel == Discord.LogSeverity.Verbose;
            runModeAsync.Checked = CSC.DefaultRunMode == RunMode.Async;
            ignoreChars.Checked = CSC.IgnoreExtraArgs;
        }
    }
}
