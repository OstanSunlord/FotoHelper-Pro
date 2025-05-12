using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FotoHelper_Pro
{
    public partial class OrganizeMyPhotos : Form
    {
        public OrganizeMyPhotos()
        {
            InitializeComponent();
        }

        private void btn_Search_orig_Click(object sender, EventArgs e)
        {
            tb_Source.Text = GetSelectedFolderPath("Select the folder containing your original photos.");
        }

        private void btn_Search_light_Click(object sender, EventArgs e)
        {
            tb_lightroom.Text = GetSelectedFolderPath("Select the folder containing your Lightroom catalog.");
        }

        private void btn_Search_desc_Click(object sender, EventArgs e)
        {
            tb_destination.Text = GetSelectedFolderPath("Select the destination folder for organized photos.");
        }

        private string GetSelectedFolderPath(string description)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = description;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderBrowserDialog.SelectedPath;
                }
            }
            return string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Validate that all textboxes contain valid directory paths  
            if (!IsValidDirectory(tb_Source.Text))
            {
                MessageBox.Show("The source folder path is invalid. Please select a valid directory.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDirectory(tb_lightroom.Text))
            {
                MessageBox.Show("The Lightroom folder path is invalid. Please select a valid directory.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDirectory(tb_destination.Text))
            {
                MessageBox.Show("The destination folder path is invalid. Please select a valid directory.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Create and show the progress dialog  
            ProgressDialog progressDialog = new ProgressDialog();
            progressDialog.ProgressBar.Minimum = 0;
            progressDialog.ProgressBar.Maximum = 100;
            progressDialog.ProgressBar.Value = 0;
            progressDialog.StatusLabel.Text = "Starting...";

            // Setup the BackgroundWorker  
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            worker.DoWork += (s, args) =>
            {
                List<Tuple<string, int>> values = new List<Tuple<string, int>>();
                var sourceList = FileHelper.GetAllFilesAndFolders(tb_Source.Text);
                var lightroomList = FileHelper.GetAllFilesAndFolders(tb_lightroom.Text);
                var count = 0;
                var dirCount = 0;
                foreach (var file in lightroomList)
                {
                    count++;
                    var foundFile = sourceList.FirstOrDefault(x => x.Name == file.Name);
                    if (foundFile != null)
                    {
                        DirectoryInfo di = new DirectoryInfo(foundFile.FullPath);
                        var di2 = new DirectoryInfo(Path.Combine(tb_destination.Text, di.Parent.FullName.Replace(di.Parent.Root.FullName, string.Empty)));
                        FileInfo fileInfo = new FileInfo(foundFile.FullPath);

                        if (!di2.Exists)
                        {
                            di2.Create();
                            values.Add(new Tuple<string, int>(di2.FullName, dirCount));
                            dirCount++;
                        }

                        var useCount = 0;
                        var dirC = values.Find(x => x.Item1 == di2.FullName);
                        if (dirC == null)
                        {
                            useCount = 0;
                        }
                        else
                        {
                            useCount = dirC.Item2;
                        }

                        var zeroPadding = int.TryParse(tb_PriZeroCount_File.Text, out int padding) ? padding : 4;
                        var zeroPaddingFolder = int.TryParse(tb_PriZeroCountFolder.Text, out int folderPadding) ? folderPadding : 2;

                        var newfile = (cb_AddImageId.Checked ? useCount.ToString("D" + zeroPaddingFolder) : string.Empty) +
                                        (cb_AddImageId.Checked && cb_AddFolderId.Checked ? "-" : string.Empty) +
                                        (cb_AddFolderId.Checked ? count.ToString("D" + zeroPadding) : string.Empty) +
                                        " " + fileInfo.Name;

                        var newFileName = Path.Combine(di2.FullName, newfile);

                        if (File.Exists(newFileName) && !cb_Move.Checked)
                        {
                            continue;
                        }
                        if (cb_override.Checked)
                        {
                            File.Delete(newFileName);
                        }

                        if (cb_Move.Checked)
                        {
                            File.Move(file.FullPath, Path.Combine(di2.FullName, newFileName));
                        }
                        else
                        {
                            File.Copy(file.FullPath, Path.Combine(di2.FullName, newFileName));
                        }
                    }

                    // Report progress  
                    worker.ReportProgress((count * 100) / lightroomList.Count, $"Processing file {count} of {lightroomList.Count}...");
                }
            };

            worker.ProgressChanged += (s, args) =>
            {
                // Update progress bar and status label  
                progressDialog.ProgressBar.Value = args.ProgressPercentage;
                progressDialog.StatusLabel.Text = args.UserState.ToString();
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                // Close the dialog when done  
                progressDialog.Close();
                MessageBox.Show("Processing completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Show the dialog and start the worker  
            progressDialog.Show(this);
            worker.RunWorkerAsync();
        }

        private bool IsValidDirectory(string path)
        {
            return !string.IsNullOrWhiteSpace(path) && System.IO.Directory.Exists(path);
        }
    }
}
