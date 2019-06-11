using System;
using System.Windows.Forms;

namespace DiscordBotManager.UI.AuthControls
{
    public partial class NewKey : Form
    {
        public NewKey() => InitializeComponent();

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.MainWindow._KEY = textBox1.Text.Trim();
            System.IO.File.WriteAllLines(Program.TOKEN_PATH, new string[] { Program.MainWindow._KEY });
            Close();
        }

        private void Button2_Click(object sender, EventArgs e) => Close();
    }
}
