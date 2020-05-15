﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Firefox_ESR_x64_Launcher
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo culture1 = CultureInfo.CurrentUICulture;
            if (File.Exists(@"Firefox ESR x64\Firefox.exe"))
            {
                var sb = new System.Text.StringBuilder();
                string[] CommandLineArgs = Environment.GetCommandLineArgs();
                for (int i = 1; i < CommandLineArgs.Length; i++)
                {
                    if (CommandLineArgs[i].Contains("="))
                    {
                        string[] test = CommandLineArgs[i].Split(new char[] { '=' }, 2);
                        sb.Append(" " + test[0] + "=\"" + test[1] + "\"");
                    }
                    else
                    {
                        sb.Append(" " + CommandLineArgs[i]);
                    }
                }
                if (!File.Exists(@"Firefox ESR x64\updates\Profile.txt"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    String Arguments = File.ReadAllText(@"Firefox ESR x64\updates\Profile.txt") + sb.ToString();
                    Process.Start(@"Firefox ESR x64\Firefox.exe", Arguments);
                }
                else
                {
                    String Arguments = File.ReadAllText(@"Firefox ESR x64\updates\Profile.txt") + sb.ToString();
                    if (File.Exists(@"Firefox ESR x64\profile\extensions.json"))
                    {
                        File.Delete(@"Firefox ESR x64\profile\extensions.json");
                        Process.Start(@"Firefox ESR x64\Firefox.exe", Arguments);
                    }
                    else if (File.Exists(@"profile\extensions.json"))
                    {
                        File.Delete(@"profile\extensions.json");
                        Process.Start(@"Firefox ESR x64\Firefox.exe", Arguments);
                    }
                    else
                    {
                        Process.Start(@"Firefox ESR x64\Firefox.exe", Arguments);
                    }
                }
            }
            else if (culture1.TwoLetterISOLanguageName == "de")
            {
                _ = MessageBox.Show("Firefox ESR x64 ist nicht installiert", "Firefox ESR x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (culture1.TwoLetterISOLanguageName == "ru")
            {
                _ = MessageBox.Show("Mozilla Firefox не найден", "Firefox Beta x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                _ = MessageBox.Show("Firefox ESR x64 is not installed", "Firefox ESR x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
