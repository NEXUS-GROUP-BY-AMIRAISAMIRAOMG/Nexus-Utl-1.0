using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using PluginSystem;

namespace NEXUS.Pages
{
    public partial class modulesPage : UserControl
    {
        private PrivateFontCollection customFonts = new PrivateFontCollection();

        public modulesPage()
        {
            InitializeComponent();
            LoadCustomFont(); // Load Caviar Dreams font
            this.Load += ModulesPage_Load; // Attach Load event
        }

        private void LoadCustomFont()
        {
            // Load the embedded font
            string resource = "NEXUS.Resources.CaviarDreams.ttf"; // Adjust to match your namespace and folder structure
            using (Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                if (fontStream == null) throw new Exception($"Font resource '{resource}' not found.");

                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, (int)fontStream.Length);

                // Allocate the font to memory
                IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
                System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                customFonts.AddMemoryFont(fontPtr, fontData.Length);
            }
        }

        private async void ModulesPage_Load(object sender, EventArgs e)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings", "modulestore.json");

            try
            {
                // Fetch JSON data from multiple URLs defined in modulestore.json
                var jsonUrls = await LoadJsonUrls(jsonFilePath); // Load the list of URLs from modulestore.json
                List<ModuleItem> allModules = new List<ModuleItem>();

                // Fetch data from each URL
                foreach (var url in jsonUrls)
                {
                    var jsonData = await FetchJsonData(url);
                    allModules.AddRange(jsonData); // Combine data from all URLs
                }

                // Populate the Downloads FlowLayoutPanel with all modules
                PopulateDownloads(allModules);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<string>> LoadJsonUrls(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = await reader.ReadToEndAsync();
                dynamic jsonData = JsonConvert.DeserializeObject(json);
                List<string> jsonUrls = jsonData.urls.ToObject<List<string>>(); // Assuming 'urls' is a list of URLs in the JSON
                return jsonUrls;
            }
        }

        private async Task<List<ModuleItem>> FetchJsonData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<ModuleItem>>(json);
            }
        }

        private void PopulateDownloads(List<ModuleItem> items)
        {
            Downloads.Controls.Clear(); // Clear previous items

            foreach (var item in items)
            {
                // Create the main panel styled for each item
                Panel itemPanel = new Panel
                {
                    BackColor = Color.FromArgb(0, 0, 16), // Set background to the desired color (0, 0, 32)
                    Margin = new Padding(10),
                    Width = Downloads.ClientSize.Width - 40 // Set the width of the panel to match the width of the FlowLayoutPanel
                };

                // Add an icon to the left
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(64, 64),
                    Location = new Point(10, 28),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                try
                {
                    pictureBox.Load(item.Icon);
                }
                catch
                {
                    pictureBox.Image = SystemIcons.Warning.ToBitmap(); // Default icon if load fails
                }

                // Add the title label
                Label lblTitle = new Label
                {
                    Text = item.Title,
                    Font = new Font(customFonts.Families[0], 14, FontStyle.Bold), // Bold title
                    ForeColor = Color.White, // White font for title
                    Location = new Point(80, 10),
                    AutoSize = true
                };

                // Add the description label
                Label lblDescription = new Label
                {
                    Text = item.Description,
                    Font = new Font(customFonts.Families[0], 10, FontStyle.Bold), // Bold description
                    ForeColor = Color.Gray, // Grey font for description (subtext)
                    Location = new Point(80, 40),
                    AutoSize = false,
                    Size = new Size(itemPanel.Width - 100, 40) // Make description as wide as the panel (adjusted width)
                };

                // Add the Download button
                Button btnDownload = new Button
                {
                    Text = "Download",
                    BackColor = Color.FromArgb(0, 160, 0), // Green background
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(80, lblDescription.Bottom + 10), // Position below description
                    Size = new Size(100, 30)
                };
                btnDownload.FlatAppearance.BorderSize = 0; // Remove button border
                btnDownload.Click += (s, e) => OpenLink(item.DownloadLink);

                // Add the Info button
                Button btnInfo = new Button
                {
                    Text = "Info",
                    BackColor = Color.FromArgb(0, 122, 204), // Blue background
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(btnDownload.Right + 10, lblDescription.Bottom + 10), // Position next to Download button
                    Size = new Size(100, 30)
                };
                btnInfo.FlatAppearance.BorderSize = 0; // Remove button border
                btnInfo.Click += (s, e) => OpenLink(item.InfoLink);

                // Adjust the height of the panel based on the buttons and description
                itemPanel.Height = btnInfo.Bottom + 10; // Make sure the panel height is large enough to contain the buttons

                // Add controls to the main panel
                itemPanel.Controls.Add(pictureBox);
                itemPanel.Controls.Add(lblTitle);
                itemPanel.Controls.Add(lblDescription);
                itemPanel.Controls.Add(btnDownload);
                itemPanel.Controls.Add(btnInfo);

                // Add the styled panel to the Downloads FlowLayoutPanel
                Downloads.Controls.Add(itemPanel);
            }
        }

        private void OpenLink(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open the link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Class to represent a module item in the JSON
        public class ModuleItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
            public string DownloadLink { get; set; }
            public string InfoLink { get; set; }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            string pluginFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            System.Diagnostics.Process.Start(pluginFolderPath);
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {

        }

        private void Downloads_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cuiButton4_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {

        }
    }
}