using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.Json;
using System.Linq.Expressions;

namespace NEXUS.Pages
{
    public partial class SingleplayerPage : UserControl
    {
        private const string VersionCheckUrl = "https://raw.githubusercontent.com/AmiraIsAmira0MG/Nexus-Updater/refs/heads/main/dllLatest";
        private string CurrentVersion;
        private const string ConfigFilePath = @"C:\Program Files (x86)\Nexus Group\Nexus Injector\Version.txt";

        public SingleplayerPage()
        {
            InitializeComponent();
            LoadCurrentVersion();
            CheckForUpdates();
        }

        private void cuiPictureBox1_Load(object sender, EventArgs e)
        {
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/gZZtysUAp3");
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\Program Files (x86)\\Nexus Group\\Nexus Injector\\Nexus DLL Injector.exe");
            }
            catch (Exception)
            {
                MessageBox.Show("Nexus DLL Injector not found. Please reinstall Nexus Injector.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start("https://github.com/AmiraIsAmiraOMG/Nexus-Injector");
            }
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
        }

        private void cuiButton4_MouseEnter(object sender, EventArgs e)
        {
            cuiButton4.Content = "Click for Github";
        }

        private async void CheckForUpdates()
        {
            try
            {
                string latestVersion = await FetchLatestVersion();

                if (IsNewerVersion(latestVersion, CurrentVersion))
                {
                    updatesTextyn.Text = "Updates Available";
                }
                else if (IsNewerVersion(CurrentVersion, latestVersion))
                {
                    updatesTextyn.Text = "Using Test Version";
                }
                else
                {
                    updatesTextyn.Text = "No Updates Available";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error checking for updates: {ex.Message}");
                updatesTextyn.Text = "Error Checking Updates";
            }
        }

        private async Task<string> FetchLatestVersion()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(VersionCheckUrl);
                response.EnsureSuccessStatusCode();
                return (await response.Content.ReadAsStringAsync()).Trim();
            }
        }

        private bool IsNewerVersion(string versionA, string versionB)
        {
            try
            {
                Version a = new Version(versionA);
                Version b = new Version(versionB);

                return a.CompareTo(b) > 0;
            }
            catch
            {
                Debug.WriteLine("Error parsing version numbers.");
                return false;
            }
        }

        private void updatesTextyn_Click(object sender, EventArgs e)
        {
        }

        private void cuiButton4_Click(object sender, EventArgs e)
        {
        }

        private void LoadCurrentVersion()
        {
            string versionFilePath = @"C:\Program Files (x86)\Nexus Group\Nexus\Version.txt";

            try
            {
                if (File.Exists(versionFilePath))
                {
                    CurrentVersion = File.ReadAllText(versionFilePath).Trim();
                }
                else
                {
                    Debug.WriteLine("Version.txt file not found.");
                    CurrentVersion = "Error";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading version from file: {ex.Message}");
            }
        }

        private void cuiButton2_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/gZZtysUAp3");
        }

        private void updatesTextyn_Click_1(object sender, EventArgs e)
        {
        }

        private void cuiButton3_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://linktr.ee/NEXUS_UTL");
        }

        private void cuiButton4_Click_1(object sender, EventArgs e)
        {
        }

        private void cuiTextBox1_ContentChanged(object sender, EventArgs e)
        {
            string newValue = cuiTextBox1.Content;
            SaveConfig(newValue);
        }

        private void SaveConfig(string dllUrl)
        {
            string configFilePath = @"C:\Program Files (x86)\Nexus Group\Nexus Injector\config.json";

            var config = new
            {
                Download = new
                {
                    DLLUrl = dllUrl
                }
            };

            try
            {
                string jsonContent = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine($"Generated JSON: {jsonContent}"); // Log the generated JSON
                File.WriteAllText(configFilePath, jsonContent);
                Console.WriteLine($"File saved at: {configFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving configuration: {ex.Message}");
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void cuiButton7_Click(object sender, EventArgs e)
        {

        }
    }
}