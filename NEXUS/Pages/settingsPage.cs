using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NEXUS.Pages
{
    public partial class settingsPage : UserControl
    {
        public settingsPage()
        {
            InitializeComponent();
        }

        private void cuiPictureBox1_Load(object sender, EventArgs e)
        {

        }

        private void cuiTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void aboutHeader_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            // Create a FolderBrowserDialog
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select the folder that contains FortniteGame and Engine folders";
                folderBrowserDialog.ShowNewFolderButton = false; // Optional: disable creating new folders

                // Show the dialog and check if the user selects a folder
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string folderPath = folderBrowserDialog.SelectedPath;

                    // Display the folder path in the TextBox
                    cuiTextBox1.Content = folderPath;
                }
            }
        }

        private void saveConfigButton_Click(object sender, EventArgs e)
        {
            // Get the values from the textboxes using .Content
            string textBox1Value = cuiTextBox1.Content.ToString(); // Using .Content for TextBox 1
            string textBox2Value = cuiTextBox2.Content.ToString(); // Using .Content for TextBox 2
            Properties.Settings.Default.FileLocation = textBox1Value;
            Properties.Settings.Default.Save();

            // Check if either textbox is empty
            if (string.IsNullOrEmpty(textBox1Value) || string.IsNullOrEmpty(textBox2Value))
            {
                MessageBox.Show("Both textboxes must have values to save the configuration.");
                return;
            }

            // Prepend "[NEXUS UTL] " to the username (textBox2Value)
            string modifiedUserName = "[NEXUS-UTL]_" + textBox2Value;

            // Replace single slashes with double slashes in the path (textBox1Value)
            string pathWithDoubleSlashes = textBox1Value.Replace("\\", "\\\\");

            // Create the dictionary to represent the data
            var configData = new
            {
                name = modifiedUserName, // Use the modified username with the prefix
                path = pathWithDoubleSlashes  // Use the value from cuiTextBox1 with corrected slashes
            };

            // Serialize the data to a JSON-like format
            string json = $"{{\"name\":\"{configData.name}\",\"path\":\"{configData.path}\"}}";

            // Specify the path to the config file, saving it under \Launchers\Singleplayer\Carbon relative to the working directory
            string workingDirectory = Directory.GetCurrentDirectory(); // Get the current working directory
            string configFolderPath = Path.Combine(workingDirectory, "Launchers", "Singleplayer", "Carbon"); // Combine the path
            string configFilePath = Path.Combine(configFolderPath, "carbon.config");

            try
            {
                // Ensure the directory exists
                if (!Directory.Exists(configFolderPath))
                {
                    Directory.CreateDirectory(configFolderPath); // Create the directory if it doesn't exist
                }

                // Write the JSON to the file
                File.WriteAllText(configFilePath, json);
                MessageBox.Show($"Configuration saved to {configFilePath} now restarting!");
                // Get the current executable's path
                string executablePath = Application.ExecutablePath;

                // Start a new instance of the program
                Process.Start(executablePath);

                // Close the current instance
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                // If an error occurs, display it in a message box
                MessageBox.Show($"Error saving configuration: {ex.Message}");
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string moduleProvider = modulesProvider.Content;
            string newsProvider = newsServiceProvider.Content;

            // Define the path to the settings folder
            string settingsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings");

            // Ensure the settings folder exists
            if (!Directory.Exists(settingsFolderPath))
            {
                Directory.CreateDirectory(settingsFolderPath);
            }

            // Paths to store the JSON data
            string moduleStorePath = Path.Combine(settingsFolderPath, "modulestore.json");
            string newsProviderPath = Path.Combine(settingsFolderPath, "news.json");

            try
            {
                // Add module provider URL to modulestore.json if not empty
                if (!string.IsNullOrEmpty(moduleProvider))
                {
                    var moduleStoreData = LoadJson(moduleStorePath);
                    moduleStoreData.urls.Add(moduleProvider); // Add new module provider URL
                    SaveJson(moduleStorePath, moduleStoreData);
                }
                else
                {
                    MessageBox.Show("Module provider is empty!");
                }

                // Add news provider URL to news.json if not empty
                if (!string.IsNullOrEmpty(newsProvider))
                {
                    var newsData = LoadJson(newsProviderPath);
                    newsData.urls.Add(newsProvider); // Add new news provider URL
                    SaveJson(newsProviderPath, newsData);
                }
                else
                {
                    Console.WriteLine("news empty");
                }

                Console.WriteLine("added providers");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding providers: {ex.Message}");
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            try
            {
                // Default URLs to reset
                var defaultModuleStore = new { urls = new[] { "https://raw.githubusercontent.com/AmiraIsAmira0MG/Nexus-Web/refs/heads/main/Nexus%20Plugin%20Store.json" } };
                var defaultNewsProvider = new { urls = new[] { "https://raw.githubusercontent.com/AmiraIsAmira0MG/Nexus-Web/refs/heads/main/Nexus%20News" } };

                // Define the path to the settings folder
                string settingsFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings");

                // Ensure the settings folder exists
                if (!Directory.Exists(settingsFolderPath))
                {
                    Directory.CreateDirectory(settingsFolderPath);
                }

                // Reset the modulestore.json file to default
                string moduleStorePath = Path.Combine(settingsFolderPath, "modulestore.json");
                SaveJson(moduleStorePath, defaultModuleStore);

                // Reset the news.json file to default
                string newsProviderPath = Path.Combine(settingsFolderPath, "news.json");
                SaveJson(newsProviderPath, defaultNewsProvider);

                Console.WriteLine("reset");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting providers: {ex.Message}");
            }
        }

        // Method to load JSON data from a file
        private dynamic LoadJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    Console.WriteLine($"Loaded JSON from {filePath}: {json}"); // Debugging line
                    return JsonConvert.DeserializeObject(json) ?? new { urls = new List<string>() };
                }
                return new { urls = new List<string>() };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON: {ex.Message}");
                return new { urls = new List<string>() };
            }
        }

        // Method to save JSON data to a file
        private void SaveJson(string filePath, object data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                Console.WriteLine($"Saving JSON to {filePath}: {json}"); // Debugging line

                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving JSON: {ex.Message}");
            }
        }

        private void newsProvider_ContentChanged(object sender, EventArgs e)
        {

        }

        private void modulesProvider_ContentChanged(object sender, EventArgs e)
        {

        }
    }
}