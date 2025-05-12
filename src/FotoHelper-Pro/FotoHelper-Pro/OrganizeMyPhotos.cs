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
            tb_Source.Text = GetSelectedFolderPath("Vælg mappen, der indeholder dine originale fotos.");
        }

        private void btn_Search_light_Click(object sender, EventArgs e)
        {
            tb_lightroom.Text = GetSelectedFolderPath("Vælg mappen, der indeholder din Lightroom-katalog.");
        }

        private void btn_Search_desc_Click(object sender, EventArgs e)
        {
            tb_destination.Text = GetSelectedFolderPath("Vælg destinationsmappen til organiserede fotos.");
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
            // Valider, at alle tekstbokse indeholder gyldige mappeveje  
            if (!IsValidDirectory(tb_Source.Text))
            {
                MessageBox.Show("Kilde-mappevejen er ugyldig. Vælg en gyldig mappe.", "Valideringsfejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDirectory(tb_lightroom.Text))
            {
                MessageBox.Show("Lightroom-mappevejen er ugyldig. Vælg en gyldig mappe.", "Valideringsfejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidDirectory(tb_destination.Text))
            {
                MessageBox.Show("Destinations-mappevejen er ugyldig. Vælg en gyldig mappe.", "Valideringsfejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Opret og vis fremdriftsdialogen  
            ProgressDialog progressDialog = new ProgressDialog()
            {
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                ControlBox = false,
                TopMost = true
            };
            progressDialog.Text = "Organiserer fotos...";

            progressDialog.ProgressBar.Minimum = 0;
            progressDialog.ProgressBar.Maximum = 100;
            progressDialog.ProgressBar.Value = 0;
            progressDialog.StatusLabel.Text = "Starter...";

            // Opsæt BackgroundWorker  
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            worker.DoWork += (s, args) =>
            {
                List<Tuple<string, int>> values = new List<Tuple<string, int>>();
                var sourceList = FileHelper.GetAllFilesAndFolders(tb_Source.Text, false);
                var lightroomList = FileHelper.GetAllFilesAndFolders(tb_lightroom.Text, false);
                var count = 0;
                var dirCount = 0;
                foreach (var file in lightroomList)
                {
                    count++;
                    try
                    {
                        var foundFile = sourceList.FirstOrDefault(x => x.Name == file.Name);
                        if (foundFile != null)
                        {
                            FileInfo fileInfo = new FileInfo(Path.Combine(tb_destination.Text, foundFile.FullPath));

                            if (!fileInfo.Directory.Exists)
                            {
                                fileInfo.Directory.Create();
                                values.Add(new Tuple<string, int>(fileInfo.Directory.FullName, dirCount));
                                dirCount++;
                            }

                            var useCount = 0;
                            var dirC = values.Find(x => x.Item1 == fileInfo.Directory.FullName);
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
                                            " " + foundFile.Name;

                            var newFileName = Path.Combine(fileInfo.Directory.FullName, newfile);

                            if (File.Exists(newFileName) && !cb_Move.Checked)
                            {
                                Console.WriteLine($"Filen {newFileName} findes allerede. Overspringer filen.");
                                continue;
                            }

                            if (cb_override.Checked)
                            {
                                File.Delete(newFileName);
                            }

                            if (cb_Move.Checked)
                            {
                                File.Move(Path.Combine(tb_lightroom.Text, foundFile.Name), newFileName);
                            }
                            else
                            {
                                File.Copy(Path.Combine(tb_lightroom.Text, foundFile.Name), newFileName);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Fejl under behandling af fil: {file.Name}. Undtagelse: {ex.Message}");
                        continue;
                    }

                    // Rapportér fremdrift  
                    worker.ReportProgress((count * 100) / lightroomList.Count, $"Behandler fil {count} af {lightroomList.Count}...");
                }
            };

            worker.ProgressChanged += (s, args) =>
            {
                // Opdater fremdriftslinje og statusetiket  
                progressDialog.ProgressBar.Value = args.ProgressPercentage;
                progressDialog.StatusLabel.Text = args.UserState.ToString();
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                // Luk dialogen, når færdig  
                progressDialog.Close();
                MessageBox.Show("Behandling afsluttet med succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            // Vis dialogen og start arbejderen  
            progressDialog.Show(this);
            worker.RunWorkerAsync();
        }

        private bool IsValidDirectory(string path)
        {
            try
            {
                // Tjek om stien ikke er null, tom eller kun mellemrum  
                if (string.IsNullOrWhiteSpace(path))
                    return false;

                // Tjek om stien er en gyldig mappe  
                if (Directory.Exists(path))
                    return true;

                // Hvis stien er et netværksdrev, forsøg at få adgang til det  
                if (path.StartsWith(@"\\") && new Uri(path).IsUnc)
                {
                    // Forsøg at få mappeoplysninger for at validere netværksstien  
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    return dirInfo.Exists;
                }
            }
            catch
            {
                // Hvis der opstår en undtagelse, er stien ugyldig  
                return false;
            }

            return false;
        }
    }
}
