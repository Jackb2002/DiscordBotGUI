using Discord.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscordBotManager.UI
{
    public partial class CommandConfigForm : Form
    {
        public CommandConfigForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CommandServiceConfig _CommandServiceConfig = new CommandServiceConfig();
            _CommandServiceConfig.CaseSensitiveCommands = caseCheck.Checked;
            _CommandServiceConfig.IgnoreExtraArgs = ignoreChars.Checked;
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
    }
}
