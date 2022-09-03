using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DiscordBotManager.UI.AuthControls
{
    public partial class NewKey : Form
    {
        public NewKey()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Path.GetDirectoryName(Program.TOKEN_PATH)))
            {
                Debug.WriteLine("Creating folder " + Path.GetDirectoryName(Program.TOKEN_PATH));
            }
            Program.MainWindow._KEY = textBox1.Text.Trim();
            if (!Directory.Exists(Path.GetDirectoryName(Program.TOKEN_PATH)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Program.TOKEN_PATH));
            }
            if (!File.Exists(Program.TOKEN_PATH))
            {
                File.Create(Program.TOKEN_PATH);
            }
            File.WriteAllLines(Program.TOKEN_PATH, new string[] { Program.MainWindow._KEY });
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
