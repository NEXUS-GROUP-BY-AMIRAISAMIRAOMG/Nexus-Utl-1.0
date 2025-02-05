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

namespace NEXUS.Pages
{
    public partial class NewsPage : UserControl
    {
        private PrivateFontCollection customFonts = new PrivateFontCollection();

        public NewsPage()
        {
            InitializeComponent();
            LoadCustomFont();
            this.Load += NewsPage_Load;
        }

        private void LoadCustomFont()
        {
            string resource = "NEXUS.Resources.CaviarDreams.ttf";
            using (Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
            {
                if (fontStream == null) throw new Exception($"Font resource '{resource}' not found.");

                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, (int)fontStream.Length);

                IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
                System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                customFonts.AddMemoryFont(fontPtr, fontData.Length);
            }
        }

        private async void NewsPage_Load(object sender, EventArgs e)
        {
            // Get the path to the settings directory
            string startupDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string settingsDirectory = Path.Combine(startupDirectory, "settings");
            string jsonFilePath = Path.Combine(settingsDirectory, "news.json");

            try
            {
                // Load the list of news URLs from the local news.json file
                List<string> urls = await LoadNewsUrls(jsonFilePath);

                // Loop over each URL and fetch news data from it
                List<NewsItem> allNewsItems = new List<NewsItem>();

                foreach (var newsUrl in urls)
                {
                    var jsonData = await FetchJsonDataFromUrl(newsUrl);  // Renamed method to avoid ambiguity
                    allNewsItems.AddRange(jsonData);
                }

                // Populate the news section with all the fetched news data
                PopulateNewsSection(allNewsItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Rename the FetchJsonData method to differentiate from the other one
        private async Task<List<NewsItem>> FetchJsonDataFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);
                return JsonConvert.DeserializeObject<List<NewsItem>>(json);
            }
        }

        // This method is for loading news URLs from the JSON file
        private async Task<List<string>> LoadNewsUrls(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = await reader.ReadToEndAsync();
                dynamic jsonData = JsonConvert.DeserializeObject(json);
                List<string> urls = jsonData.urls.ToObject<List<string>>(); // Changed from newsUrls to urls
                return urls;
            }
        }

        private void PopulateNewsSection(List<NewsItem> items)
        {
            Downloads.Controls.Clear();

            // Configure the FlowLayoutPanel for vertical stacking
            Downloads.FlowDirection = FlowDirection.TopDown;
            Downloads.WrapContents = false; // Ensure vertical stacking
            Downloads.AutoScroll = true;    // Enable only vertical scrolling
            Downloads.HorizontalScroll.Maximum = 0; // Disable horizontal scrollbar
            Downloads.HorizontalScroll.Visible = false; // Ensure it stays hidden
            Downloads.AutoScroll = true;
            Downloads.Padding = new Padding(0);
            Downloads.Dock = DockStyle.Fill;

            foreach (var item in items)
            {
                // Create the main panel for the news item
                Panel itemPanel = new Panel
                {
                    BackColor = Color.FromArgb(0, 0, 16), // Dark background color
                    Margin = new Padding(0, 0, 0, 10),   // Remove side margins
                    Padding = new Padding(10),           // Inner padding
                    AutoSize = true,                     // Adjust height based on content
                    Width = Downloads.ClientSize.Width   // Match FlowLayoutPanel's width
                };

                // Add an icon
                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(64, 64),
                    Margin = new Padding(0, 0, 10, 0),   // Padding to the right of the icon
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent         // Transparent background for the icon
                };
                try
                {
                    pictureBox.Load(item.Icon);
                }
                catch
                {
                    pictureBox.Image = SystemIcons.Warning.ToBitmap(); // Fallback icon
                }

                // Add a title label
                Label lblTitle = new Label
                {
                    Text = item.Title,
                    Font = new Font(customFonts.Families[0], 14, FontStyle.Bold),
                    ForeColor = Color.White,
                    AutoSize = true,
                    BackColor = Color.Transparent         // Transparent background for text
                };

                // Add a description label
                Label lblDescription = new Label
                {
                    Text = item.Description,
                    Font = new Font(customFonts.Families[0], 10),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    MaximumSize = new Size(Downloads.ClientSize.Width - 80, 0), // Limit width to available space
                    BackColor = Color.Transparent         // Transparent background for text
                };

                // Create a horizontal FlowLayoutPanel for buttons
                FlowLayoutPanel buttonPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    WrapContents = false,                // Keep buttons in a single row
                    Margin = new Padding(0, 10, 0, 0),   // Spacing above the buttons
                    BackColor = Color.Transparent        // Transparent background for buttons
                };

                // Add buttons dynamically based on the JSON
                foreach (var button in item.Buttons)
                {
                    Button actionButton = new Button
                    {
                        Text = button.Text,
                        BackColor = Color.FromArgb(0, 122, 204), // Blue background
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Size = new Size(100, 30),               // Fixed button size for consistency
                        Margin = new Padding(5, 0, 5, 0)       // Add spacing between buttons
                    };
                    actionButton.FlatAppearance.BorderSize = 0;

                    actionButton.Click += (s, e) => OpenLink(button.Link);
                    buttonPanel.Controls.Add(actionButton);
                }

                // Use a TableLayoutPanel for clean alignment
                TableLayoutPanel layout = new TableLayoutPanel
                {
                    ColumnCount = 2,
                    RowCount = 3,
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    BackColor = Color.Transparent         // Transparent background for the layout
                };
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Icon column
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100)); // Content column
                layout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Title row
                layout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Description row
                layout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Button row

                // Add controls to the layout
                layout.Controls.Add(pictureBox, 0, 0);
                layout.SetRowSpan(pictureBox, 3); // Span icon across all rows
                layout.Controls.Add(lblTitle, 1, 0);
                layout.Controls.Add(lblDescription, 1, 1);
                layout.Controls.Add(buttonPanel, 1, 2);

                // Add the layout to the panel
                itemPanel.Controls.Add(layout);

                // Add the completed panel to the main FlowLayoutPanel
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

        public class NewsItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
            public List<NewsButton> Buttons { get; set; }
        }

        public class NewsButton
        {
            public string Text { get; set; }
            public string Link { get; set; }
        }

        private void Downloads_Paint(object sender, PaintEventArgs e) { }
    }
}