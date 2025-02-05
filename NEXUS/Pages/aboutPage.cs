using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEXUS.Pages
{
    public partial class aboutPage : UserControl
    {
        public aboutPage()
        {
            InitializeComponent();
        }

        private void cuiPictureBox1_Load(object sender, EventArgs e)
        {

        }

        private void aboutText_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void creditsText_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to open the profiles of everyone involved?", 
            "There is alot of tabs", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Process.Start("https://discord.com/users/889045882874495036");
                Process.Start("https://discord.com/users/1102803726554628137");
                Process.Start("https://discord.com/users/1095279162920542218");
                Process.Start("https://discord.com/users/928719633660383292");
                Process.Start("https://discord.com/users/1189209526403080202");
                Process.Start("https://discord.com/users/1062920333214101585");
                Process.Start("https://discord.com/users/759083243097686036");
                Process.Start("https://discord.com/users/680140129284915219");
            }
            else
            {

            }
        }

        private void nexusVersionBody_Click(object sender, EventArgs e)
        {

        }
    }
}
