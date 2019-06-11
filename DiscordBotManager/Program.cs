﻿using DiscordBotManager.UI;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DiscordBotManager
{
    static class Program
    {
        public static string TOKEN_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BOTTKN.dat";
        /// <summary>
        /// Main Instance Of UI Window
        /// </summary>
        public static MainUI MainWindow;
        /// <summary>
        /// The Debug State Of The Program Default False Unless In Debug Mode
        /// </summary>
        public static bool _DEBUG { get; private set; } = false;
        /// <summary>
        /// The String Printed On Incorrect Arguments Passed
        /// </summary>
        const string argString = "DiscordManager.exe <debug,true/false> \n" +
            " Example - DiscordManager.exe true";

        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args">Passed Arguments</param>
        static void Main(string[] args)
        {
#if DEBUG
            _DEBUG = true; // set debug mode to true if its a debug build 
#endif
            if (args.Length >= 2)
            {
                foreach (var argument in args)
                {
                    try
                    {
                        Convert.ToBoolean(args[1]);
                    }
                    catch (FormatException)
                    {
                        Debug.WriteLine("Invalid Format Of Arguments Expected " + argString);
                    }
                }
            }
            Debug.WriteLine("Starting UI Thread...");
            LoadUI();
        }

        /// <summary>
        /// Loads The UI Element Of The Bot
        /// </summary>
        [STAThread]
        static void LoadUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow = new MainUI(); // create window instance
            Application.Run(MainWindow);
        }
    }
}
