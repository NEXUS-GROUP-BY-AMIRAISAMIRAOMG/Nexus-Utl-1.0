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

namespace NEXUS.Pages
{
    public partial class dllPage : UserControl
    {
        public dllPage()
        {
            InitializeComponent();
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            string workingDirectory = Application.StartupPath;
            string filepath = Path.Combine(workingDirectory, "Launchers", "Singleplayer", "Carbon", "CarbonLauncher.exe");
            Process.Start(filepath);
        }

        private void updatesTextyn_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton4_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton3_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://linktr.ee/NEXUS_UTL");
        }

        private void cuiButton2_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/gZZtysUAp3");
        }

        private void updatesTextyn_Click_1(object sender, EventArgs e)
        {

        }

        private void cuiButton4_Click_1(object sender, EventArgs e)
        {

        }

        private void cuiPictureBox1_Load(object sender, EventArgs e)
        {

        }

        private void cuiPictureBox2_Load(object sender, EventArgs e)
        {

        }

        private void cuiButton9_Click(object sender, EventArgs e)
        {

        }
    }
}
