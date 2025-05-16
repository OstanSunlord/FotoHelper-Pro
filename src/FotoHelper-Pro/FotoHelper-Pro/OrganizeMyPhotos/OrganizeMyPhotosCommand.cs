using FotoHelper_Pro.Interfaces;
using FotoHelper_Pro.library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoHelper_Pro
{
    internal class OrganizeMyPhotosCommand : FotoCommand
    {
        public OrganizeMyPhotosCommand() : base()
        {
            _name = "Organiser mine fotos";
        }

        public override void Execute()
        {
            var dialog = new OrganizeMyPhotos();
            dialog.doExecute += Dialog_doExecute;
            dialog.ShowDialog();
        }

        private void Dialog_doExecute(object sender, OrganizeMyPhotosEventArgs e)
        {
            if (sender is OrganizeMyPhotos dialog)
            {
                dialog.DataValidate();

                var missingFiles = new List<string>();

                var thead = new ProgressDialog("Organiserer fotos...", worker =>
                {
                    List<DirectoryEntry> values = new List<DirectoryEntry>();
                    var sourceList = FileHelper.GetAllFilesAndFolders(e.SourcePath, false);
                    var lightroomList = FileHelper.GetAllFilesAndFolders(e.LightroomPath, false);
                    var count = 0;
                    var dirCount = 0;
                    foreach (var file in lightroomList)
                    {
                        count++;
                        try
                        {
                            var newName = file.Name;
                            var foundFile = sourceList.FirstOrDefault(x => x.Name.Equals(file.Name, StringComparison.CurrentCultureIgnoreCase));

                            if (foundFile == null)
                            {
                                var extension = Path.GetExtension(file.Name);
                                var newextension = Path.GetExtension(file.Name);
                                switch (extension.ToLower())
                                {
                                    case ".jpg": newextension = ".jpeg"; break;
                                }

                                newName = newName.Replace(extension, newextension);

                                foundFile = sourceList.FirstOrDefault(x => x.Name.Equals(newName, StringComparison.CurrentCultureIgnoreCase));

                                if (foundFile == null)
                                {
                                    /*
                                    var ext = Path.GetExtension(file.Name);
                                    var baseName = string.Join("-", newName.Replace(newextension, string.Empty).Split('-').TakeWhile(part => !int.TryParse(part, out _)));

                                    var files = sourceList
                                        .Where(x =>
                                        {
                                            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(x.Name);
                                            return fileNameWithoutExt.StartsWith(baseName, StringComparison.OrdinalIgnoreCase);
                                        })
                                        .ToList();

                                    FileInfo lightroomFile = new FileInfo(Path.Combine(tb_lightroom.Text, file.Name));

                                    FileInfo matchedFile = null;
                                    TimeSpan minDifference = TimeSpan.MaxValue;
                                    foreach (var f in files)
                                    {
                                        FileInfo candidateFile = new FileInfo(Path.Combine(tb_Source.Text, f.FullPath));

                                        // Compare creation times
                                        var diff = (candidateFile.CreationTime - lightroomFile.CreationTime).Duration(); // .Duration() gives absolute value

                                        if (diff < minDifference)
                                        {
                                            minDifference = diff;
                                            matchedFile = candidateFile;
                                        }
                                    }
                                    */

                                    missingFiles.Add(file.Name);
                                    continue;
                                }
                            }

                            if (foundFile != null)
                            {
                                FileInfo fileInfo = new FileInfo(Path.Combine(e.DestinationPath, foundFile.FullPath));

                                var aktivDirectory = values.Find(x => x.FullName == fileInfo.Directory.FullName);

                                if (aktivDirectory == null)
                                {
                                    fileInfo.Directory.Create();
                                    aktivDirectory = new DirectoryEntry() { FullName = fileInfo.Directory.FullName, Index = ++dirCount };
                                    values.Add(aktivDirectory);
                                }

                                var newfile = (e.AddImageId ? aktivDirectory.Index.ToString("D" + e.FolderZeroPadding) : string.Empty) +
                                                (e.AddImageId && e.AddFolderId ? "-" : string.Empty) +
                                                (e.AddFolderId ? count.ToString("D" + e.FileZeroPadding) : string.Empty) +
                                                " " + foundFile.Name;

                                var newFileName = Path.Combine(fileInfo.Directory.FullName, newfile);

                                if (File.Exists(newFileName) && !e.MoveFiles)
                                {
                                    Console.WriteLine($"Filen {newFileName} findes allerede. Overspringer filen.");
                                    continue;
                                }

                                if (e.OverrideFiles)
                                {
                                    File.Delete(newFileName);
                                }

                                if (e.MoveFiles)
                                {
                                    File.Move(Path.Combine(e.LightroomPath, file.Name), newFileName);
                                }
                                else
                                {
                                    File.Copy(Path.Combine(e.LightroomPath, file.Name), newFileName);
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

                    worker.RunWorkerCompleted += (s, args) =>
                    {
                        if (missingFiles.Any())
                        {
                            string message = "Følgende filer blev ikke fundet:\n\n" + string.Join("\n", missingFiles);
                            MessageBox.Show(message, "Manglende filer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (args.Error != null)
                        {
                            MessageBox.Show($"Fejl under behandling af filer: {args.Error.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Filer og mapper er blevet tagget.", "Færdig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    };
                });
                /*
                // Opret og vis fremdriftsdialogen  
                ProgressDialog progressDialog = new ProgressDialog()
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    ShowInTaskbar = false,
                    ControlBox = false
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

                    if (missingFiles.Any())
                    {
                        string message = "Følgende filer blev ikke fundet:\n\n" + string.Join("\n", missingFiles);
                        MessageBox.Show(message, "Manglende filer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    MessageBox.Show("Behandling afsluttet med succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                // Vis dialogen og start arbejderen  
                progressDialog.Show(dialog);
                worker.RunWorkerAsync();
                */
            }
        }
    }
}
