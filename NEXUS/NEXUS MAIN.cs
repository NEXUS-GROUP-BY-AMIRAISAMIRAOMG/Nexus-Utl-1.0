using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using NEXUS.Pages;
using System.Configuration;
using Newtonsoft.Json;
using DiscordRPC;
using DiscordRPC.Logging;

namespace NEXUS
{
    public partial class Form1 : Form
    {
        // Dictionary to store all pages for quick access
        private readonly Dictionary<string, UserControl> pages = new Dictionary<string, UserControl>();
        private DiscordRpcClient rpcClient;

        public Form1(string[] args)
        {
            InitializeComponent();
            this.KeyPreview = true; // Allow the form to capture key events
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // Attach the event handler
            InitializePages(); // Initialize all pages

            // Enable drag-and-drop for the form
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            ShowPage("homePage");
            windowTitle.Text = "NEXUS UTILITIES HOME";

            Topmostcheck();

            // Initialize Discord Rich Presence
            InitializeDiscordRPC();

            // Handle command-line arguments for file association
            if (args.Length > 0)
            {
                string filePath = args[0];
                if (File.Exists(filePath))
                {
                    OpenModFile(filePath);
                }
                else
                {
                    MessageBox.Show($"The file \"{filePath}\" does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Define workingDirectory as the application's startup directory
            string workingDirectory = Application.StartupPath;

            // Construct the full path to CarbonLauncher.exe
            string filepath = Path.Combine(workingDirectory, "Launchers", "Singleplayer", "Carbon", "CarbonLauncher.exe");

            // Check if the file exists
            if (File.Exists(filepath))
            {
                // File exists - no action needed
            }
            else
            {
                // File does not exist - show the Carbonnotinstalled form
                Carbonnotinstalled carbonForm = new Carbonnotinstalled();
                carbonForm.ShowDialog(); // Use ShowDialog() if you want it to block
            }
        }

        /// Initialize Discord Rich Presence
        private void InitializeDiscordRPC()
        {
            rpcClient = new DiscordRpcClient("1312481188358918184"); // Your App ID
            rpcClient.OnReady += (sender, e) =>
            {
                Console.WriteLine("Discord RPC connected!");
            };
            rpcClient.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Presence updated!");
            };

            rpcClient.Initialize();

            // Set initial Rich Presence
            rpcClient.SetPresence(new RichPresence()
            {
                Details = "1.1.0",
                State = "Nexus Group",
                Assets = new Assets()
                {
                    LargeImageKey = "project_nexus",
                    LargeImageText = "https://discord.gg/gZZtysUAp3",
                    SmallImageKey = "avatar",
                    SmallImageText = "By AmiraIsAmiraOMG"
                }
            });

            // Periodically update the Discord client
            Task.Run(async () =>
            {
                while (true)
                {
                    rpcClient.Invoke();
                    await Task.Delay(1000);
                }
            });
        }

        /// Cleanup Discord RPC when form closes
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            rpcClient.Dispose();
        }

        // Handle the DragEnter event to show the correct cursor
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // Indicate a copy operation
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // Handle the DragDrop event to process the file
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                string filePath = files[0];
                if (File.Exists(filePath))
                {
                    OpenModFile(filePath); // Process the dropped file
                }
                else
                {
                    MessageBox.Show($"The file \"{filePath}\" does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// Initializes all pages and stores them in a dictionary.
        private void InitializePages()
        {
            pages["SingleplayerPage"] = new SingleplayerPage();
            pages["aboutPage"] = new aboutPage();
            pages["homePage"] = new homePage();
            pages["dllPage"] = new dllPage();
            pages["modulesPage"] = new modulesPage();
            pages["settingsPage"] = new settingsPage();
            pages["newsPage"] = new NewsPage();

            // Preload all pages
            foreach (var page in pages.Values)
            {
                page.Dock = DockStyle.Fill;
            }
        }

        /// Shows a specific page by name.
        private void ShowPage(string pageName)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(pages[pageName]);
        }

        // TITLE BAR
        private void nexusClick(object sender, EventArgs e)
        {
            Process.Start("https://linktr.ee/NEXUS_UTL");
        }

        private void minimise(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        // PAGES
        private void HomePage(object sender, EventArgs e)
        {
            windowTitle.Text = "NEXUS UTILITIES HOME";
            ShowPage("homePage");
        }

        private void modsPage(object sender, EventArgs e)
        {
            // Implement the mods page logic here
        }

        private void injectorPage(object sender, EventArgs e)
        {
            windowTitle.Text = "NEXUS UTILITIES DLL";
            ShowPage("SingleplayerPage");
        }

        private void newsPage(object sender, EventArgs e)
        {
            windowTitle.Text = "NEXUS UTILITIES NEWS";
            ShowPage("newsPage");
        }

        private void settingsPage(object sender, EventArgs e)
        {
            windowTitle.Text = "NEXUS UTILITIES SETTINGS";
            ShowPage("settingsPage");
        }

        private void modulesPage(object sender, EventArgs e)
        {
            windowTitle.Text = "NEXUS UTILITIES PLUGIN STORE";
            ShowPage("modulesPage");
        }

        private void aboutPage(object sender, EventArgs e)
        {
            windowTitle.Text = "NEXUS UTILITIES ABOUT";
            ShowPage("aboutPage");
        }

        private void formBackground_Load(object sender, EventArgs e)
        {
            // Implement any logic for form background load
        }

        private void cuiPictureBox3_Load(object sender, EventArgs e)
        {
            // Implement logic for PictureBox load if necessary
        }

        /// Opens a .Nexus file and processes its content.
        private void OpenModFile(string filePath)
        {
            try
            {
                // Retrieve the saved location from application settings
                string savedLocation = Properties.Settings.Default.FileLocation;

                // Validate if savedLocation is set
                if (string.IsNullOrEmpty(savedLocation))
                {
                    MessageBox.Show("Saved location is not configured. Please set it in the settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Paths
                string paksFolder = Path.Combine(savedLocation, "FortniteGame", "Content", "Paks");
                string nexusGroupFolder = Path.Combine(savedLocation, "FortniteGame", "Content", "NexusGroup");
                string modsJsonPath = Path.Combine(nexusGroupFolder, "mods.json");

                // Ensure necessary directories exist
                if (!Directory.Exists(paksFolder))
                {
                    Directory.CreateDirectory(paksFolder);
                }
                if (!Directory.Exists(nexusGroupFolder))
                {
                    Directory.CreateDirectory(nexusGroupFolder);
                }

                // Load or create mods.json
                List<dynamic> modsList = new List<dynamic>();
                if (File.Exists(modsJsonPath))
                {
                    string existingJson = File.ReadAllText(modsJsonPath);
                    modsList = JsonConvert.DeserializeObject<List<dynamic>>(existingJson) ?? new List<dynamic>();
                }

                // Get the file extension to handle accordingly
                string fileExtension = Path.GetExtension(filePath).ToLower();
                string modFileName = Path.GetFileName(filePath);

                // Check if the mod is already added
                if (modsList.Any(mod => mod.ModFile == modFileName))
                {
                    MessageBox.Show("This mod is already installed.", "Duplicate Mod", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Copy the mod file (.nexus, .rift, .zip) to the Paks folder
                string newFilePath = Path.Combine(paksFolder, modFileName);
                File.Copy(filePath, newFilePath); // Copy instead of move

                // Extract the file if it's a .nexus, .rift, or .zip file
                string tempFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFolder);

                // Extract based on file extension
                if (fileExtension == ".zip" || fileExtension == ".rift" || fileExtension == ".nexus")
                {
                    System.IO.Compression.ZipFile.ExtractToDirectory(filePath, tempFolder);
                }

                // Look for metadata.json inside the extracted contents
                string metadataFilePath = Path.Combine(tempFolder, "metadata.json");

                // Initialize list for file names (pak, sig, etc.)
                List<string> extractedFileNames = new List<string>();

                // If the metadata.json file exists, read it and log it to mods.json
                dynamic metadata = null;
                if (File.Exists(metadataFilePath))
                {
                    string metadataJson = File.ReadAllText(metadataFilePath);
                    metadata = JsonConvert.DeserializeObject<dynamic>(metadataJson);
                }
                else
                {
                    // If metadata.json is not found, show a warning to the user
                    MessageBox.Show("Warning: No metadata.json found in the mod file. The mod will be installed without metadata.", "Metadata Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Move both .pak and .sig files directly into the Paks folder
                var extractedFiles = Directory.GetFiles(tempFolder, "*.*", SearchOption.AllDirectories);
                foreach (var extractedFile in extractedFiles)
                {
                    string fileName = Path.GetFileName(extractedFile);
                    string fileExtensionInTemp = Path.GetExtension(extractedFile).ToLower();

                    // Check if the file is .pak or .sig before copying
                    if (fileExtensionInTemp == ".pak" || fileExtensionInTemp == ".sig")
                    {
                        string destinationPath = Path.Combine(paksFolder, fileName);
                        // If a file with the same name exists, overwrite it
                        File.Copy(extractedFile, destinationPath, overwrite: true);
                        extractedFileNames.Add(fileName); // Add file name to the list for logging
                    }
                }

                // Combine the metadata and files into one entry
                modsList.Add(new
                {
                    ModFile = modFileName,
                    AddedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Files = extractedFileNames,
                    Metadata = metadata ?? new { } // If metadata is null, we add an empty object
                });

                // Save the updated mods.json with mod details and metadata
                File.WriteAllText(modsJsonPath, JsonConvert.SerializeObject(modsList, Formatting.Indented));

                // Now delete the original mod file in the Paks folder after logging to mods.json
                if (File.Exists(newFilePath))
                {
                    File.Delete(newFilePath); // Delete the original file (e.g., .nexus, .rift, .zip) after extraction
                }

                // Delete the temporary folder and its contents
                Directory.Delete(tempFolder, recursive: true);

                // Notify the user
                MessageBox.Show($"File copied, extracted, logged to mods.json, and original mod file deleted:\n{modsJsonPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void nexusIcon_Load(object sender, EventArgs e)
        {

        }

        private void windowTitle_DragEnter(object sender, DragEventArgs e)
        {
            this.ActiveControl = null; // Redirect focus away from the label
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            windowTitle.Text = "NEXUS UTILITIES SINGLEPLAYER";
            ShowPage("dllPage");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void windowTitle_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Check if Enter key is pressed
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "MOD Files (*.nexus;*.rift;*.zip)|*.nexus;*.rift;*.zip|All Files (*.*)|*.*";
                    openFileDialog.Title = "Select a Fortnite Mod File";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        if (File.Exists(filePath))
                        {
                            OpenModFile(filePath); // Process the selected file
                        }
                        else
                        {
                            MessageBox.Show($"The file \"{filePath}\" does not exist.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void Topmostcheck()
        {
            TopMost = true;
            Task.Delay(10000);
            TopMost = false;
        }
    }
}