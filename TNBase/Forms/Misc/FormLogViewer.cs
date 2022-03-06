using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TNBase.DataStorage;

namespace TNBase
{
    public partial class FormLogViewer : Form
    {
        private string lastUpdate = "";
        private string logFilePath;

        public FormLogViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Highlight log text by color
        /// </summary>
        private void UpdateText(string update)
        {
            txtLog.Clear();
            txtLog.Text = string.Empty;

            // Loop through lines in update
            using (StringReader reader = new StringReader(update))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Color foreColor = Color.Black;
                    Color backColor = Color.White;

                    if (line.Contains("TRACE"))
                    {
                        foreColor = Color.LightGray;
                    }
                    else if (line.Contains("DEBUG"))
                    {
                        foreColor = Color.Gray;
                    }
                    else if (line.Contains("WARN"))
                    {
                        foreColor = Color.Orange;
                    }
                    else if (line.Contains("ERROR"))
                    {
                        foreColor = Color.Red;
                    }
                    else if (line.Contains("FATAL"))
                    {
                        backColor = Color.Black;
                        foreColor = Color.Red;
                    }
                    line += Environment.NewLine;
                    
                    txtLog.MyAppendText(line, foreColor, backColor);
                }
            }

            // Scroll to the end
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        /// <summary>
        /// Keep the log file up to date!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logUpdater_Tick(object sender, EventArgs e)
        {
            // Get the log
            if (File.Exists(logFilePath))
            {
                // Only update if its changed
                string newContent = File.ReadAllText(logFilePath);
                if (!lastUpdate.Equals(newContent))
                {
                    lastUpdate = newContent;
                    UpdateText(lastUpdate);
                }
            }
            else
            {
                txtLog.Clear();
                txtLog.Text = "Couldn't load log file, does it exist at: '" + logFilePath + "' ? "; 
            }
        }

        /// <summary>
        /// When the form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formLogViewer_Load(object sender, EventArgs e)
        {
            logFilePath = ModuleGeneric.GetLogFilePath();
            LogFileLocationLink.Text = Path.GetDirectoryName(logFilePath);
        }

        private void LogFileLocationLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", Path.GetDirectoryName(logFilePath));
        }
    }
}
