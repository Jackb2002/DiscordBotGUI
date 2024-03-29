﻿using System;
using System.Diagnostics;
using System.IO;
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
            if (!Directory.Exists(Path.GetDirectoryName(Program.FLAKE_PATH)))
            {
                Debug.WriteLine("Creating folder " + Path.GetDirectoryName(Program.FLAKE_PATH));
            }
            Program.MainWindow._FLAKE = textBox1.Text.Trim();
            if (!Directory.Exists(Path.GetDirectoryName(Program.FLAKE_PATH)))
            {
                _ = Directory.CreateDirectory(Path.GetDirectoryName(Program.FLAKE_PATH));
            }
            if (!File.Exists(Program.FLAKE_PATH))
            {
                _ = File.Create(Program.FLAKE_PATH);
            }
            File.WriteAllLines(Program.FLAKE_PATH, new string[] { Program.MainWindow._FLAKE });
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
