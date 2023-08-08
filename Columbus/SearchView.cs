using Columbus.Common;
using Columbus.Domain;
using Columbus.Wrappers;
using Microsoft.VisualBasic.Devices;
using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace Columbus
{
    public partial class SearchView : Form
    {
        private List<string> matchingFiles = new List<string>();
        private CancellationTokenSource cancellationTokenSource;
        private int processedFiles;
        private readonly IOHandler handler = new(new DirectoryWrapper(), new FileWrapper(), new PathWrapper());
        public bool UniqueOnly => checkBox1.Checked;
        public SearchOption SearchType
        {
            get
            {
                if (checkBox2.Checked)
                {
                    return SearchOption.TopDirectoryOnly;
                }

                return SearchOption.AllDirectories;
            }
        }
        public SearchView()
        {
            InitializeComponent();
        }

        private async Task SearchForFilesAsync(string folderPath, string searchKeyword, CancellationToken cancellationToken)
        {
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Invalid folder path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clear the previous images and items in the ListBox
            checkedListBoxImages.Items.Clear();
            lbl_progress.Text = "";
            processedFiles = 0;

            IProgress<int> progress = new Progress<int>(report =>
            {
                lbl_progress.Text = $"Found {report} matches!";
            });

            var matches = new List<string>();

            try
            {
                await Task.Run(async () =>
                {
                    await foreach (var file in handler.EnumerateFilesByNameAsync(folderPath, $"*{searchKeyword}*", SearchType, UniqueOnly, cancellationToken).WithCancellation(cancellationToken))
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        matches.Add(file);

                        if (processedFiles % 1764 == 0 || processedFiles == 0) // Adjust the interval as needed
                        {
                            progress.Report(processedFiles);
                        }

                        processedFiles++;
                    }
                }, cancellationToken);

                if (matches.Count == 0)
                {
                    MessageBox.Show("No matching files found.", "No Results Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    progress.Report(processedFiles);
                    MessageBox.Show($"{matches.Count} matches found!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (OperationCanceledException)
            {
                progress.Report(processedFiles);
                MessageBox.Show($"Search stopped {matches.Count} icons found!", "Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            checkedListBoxImages.Items.AddRange(matches.ToArray());
        }

        private async Task SearchByKeyword(string keyword)
        {
            string folderPath = txtFolderPath.Text;

            btnSearch.Enabled = false; // Disable the "Search" button before the search starts
            btnSearch.Text = "Fetching...";
            btnCancelSearch.Enabled = true; // Enable the "Cancel" button during the search
            btnCopy.Enabled = false;
            txtSearchKeyword.Enabled = false;
            txtFolderPath.Enabled = false;
            chkBoxSelectAll.Enabled = false;
            progressBar.Visible = true;
            lbl_progress.Visible = true;

            ShowLoadingIndicator();
            // Create a new cancellation token source and pass its token to the search method
            cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            await SearchForFilesAsync(folderPath, keyword, cancellationToken);

            btnCancelSearch.Enabled = false; // Disable the "Cancel" button after the search
            btnSearch.Enabled = true; // Enable the "Search" button after the search is completed
            btnCopy.Enabled = true;
            btnSearch.Text = "Search";
            txtSearchKeyword.Enabled = true;
            txtFolderPath.Enabled = true;
            chkBoxSelectAll.Enabled = true;
            HideLoadingIndicator();
            progressBar.Visible = false; // Hide the progress bar when the search is completed or cancelled
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearchKeyword.Text;
            await SearchByKeyword(searchKeyword);
        }

        private async void checkedListBoxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxImages.SelectedIndex != -1)
            {
                int selectedIndex = checkedListBoxImages.SelectedIndex;
                if (selectedIndex < matchingFiles.Count)
                {
                    string selectedImagePath = matchingFiles[selectedIndex]; // Retrieve the full path from the separate list
                    if (IsImageFile(selectedImagePath))
                    {
                        await LoadImageAsync(selectedImagePath);
                    }
                }
            }
        }

        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                btnCancelSearch.Enabled = false;
                // Cancel the search operation if the "Cancel" button is clicked
                cancellationTokenSource.Cancel();
            }
        }

        private async Task LoadImageAsync(string imagePath)
        {
            try
            {
                // Show the loading text while the image is being loaded
                ShowLoadingIndicator();

                // Load the image asynchronously in the background
                Image image;
                using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    image = await Task.Run(() => Image.FromStream(stream));
                }

                // Set the image to the PictureBox
                pictureBox.Image = image;

                // Center the image inside the PictureBox
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;

                // Hide the loading text once the image is loaded
                HideLoadingIndicator();
            }
            catch (Exception ex)
            {
                HideLoadingIndicator(); // Hide the loading text in case of an error
                MessageBox.Show("Error loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoadingIndicator()
        {
            // Show "Loading..." text in the center of the PictureBox.
            Label loadingLabel = new Label
            {
                Text = "Loading...",
                ForeColor = Color.White,
                BackColor = Color.Gray,
                Font = new Font("Arial", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            pictureBox.Image = null;
            pictureBox.Controls.Add(loadingLabel);
        }

        private void HideLoadingIndicator()
        {
            // Remove the loading text from the PictureBox.
            pictureBox.Controls.Clear();
        }

        private bool IsImageFile(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            return (extension == ".png" || extension == ".jpg" || extension == ".jpeg");
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            SaveFiles();
        }

        private void SaveFiles()
        {
            if (checkedListBoxImages.CheckedItems.Count > 0)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Set the file filter to save only zip files
                    saveFileDialog.Filter = "Zip Files|*.zip";
                    saveFileDialog.FileName = $"{DateTime.Now:dd-MM-yyyy-HH-mm-ss}_IconFinder.zip";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (FileStream zipToCreate = new FileStream(saveFileDialog.FileName, FileMode.Create))
                            {
                                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                                {
                                    foreach (var checkedItem in checkedListBoxImages.CheckedItems)
                                    {
                                        int selectedIndex = checkedListBoxImages.Items.IndexOf(checkedItem);
                                        if (selectedIndex < matchingFiles.Count)
                                        {
                                            string selectedImagePath = matchingFiles[selectedIndex];
                                            string fileName = Path.GetFileName(selectedImagePath);
                                            archive.CreateEntryFromFile(selectedImagePath, fileName);
                                        }
                                    }
                                }
                            }

                            MessageBox.Show("Icons Successfully Zipped.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while creating the zip file: " + ex.Message, "Internal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one image to zip.", "No Icons Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetChecked(bool isChecked)
        {
            for (int i = 0; i < checkedListBoxImages.Items.Count; i++)
            {
                checkedListBoxImages.SetItemChecked(i, isChecked);
            }
        }

        private void chkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(chkBoxSelectAll.Checked);
        }

        private async void btnAllUniqueIcons_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("This process fetches all unique icon files within the define search location. May take some time, do you want to continue?", "Slow Process Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (response == DialogResult.Yes)
            {
                await SearchByKeyword("");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}