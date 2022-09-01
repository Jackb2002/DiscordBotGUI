using System;
using System.Windows.Forms;

namespace DiscordBotManager.UI.AuthControls
{
    public partial class NewSnowflake : Form
    {
        public NewSnowflake()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.MainWindow._FLAKE = textBox1.Text.Trim();
            System.IO.File.WriteAllLines(Program.FLAKE_PATH, new string[] { Program.MainWindow._FLAKE });
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
