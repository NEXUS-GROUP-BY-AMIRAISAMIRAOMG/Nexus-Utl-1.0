using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXUS
{
    public partial class Carbonnotinstalled : Form
    {
        public Carbonnotinstalled()
        {
            InitializeComponent();
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Doing this will stop singleplayer working. are you ok with this?", "ARE YOU SURE", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Close();
            }

            if (result == DialogResult.Cancel)
            {
                
            }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            string workingDirectory = Application.StartupPath;
            string filepath = Path.Combine(workingDirectory, "Launchers", "Singleplayer", "Carbon");

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            Process.Start("explorer.exe", filepath);
            Process.Start("https://discord.gg/YaZAHNYgZc");
            Process.Start("https://discord.gg/YaZAHNYgZc");
        }

        private void cuiButton4_Click(object sender, EventArgs e)
        {
            // Get the current executable's path
            string executablePath = Application.ExecutablePath;

            // Start a new instance of the program
            Process.Start(executablePath);

            // Close the current instance
            Environment.Exit(0);
        }
    }
}
