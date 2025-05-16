using FotoHelper_Pro.Interfaces;
using FotoHelper_Pro.library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoHelper_Pro
{
    internal class TagFilesandFolderCommand : FotoCommand
    {
        public TagFilesandFolderCommand()
            : base()
        {
            _name = "Tag Files and Folder";
        }

        public override void Execute()
        {
            var dialog = new TagFilesandFolder();

            dialog.doExecute += Dialog_doExecute;
            dialog.ShowDialog();
        }

        private void Dialog_doExecute(object sender, TagFilesandFolderEventArgs e)
        {
            try
            {
                if (sender is TagFilesandFolder dialog)
                {
                    dialog.DataValidate();
                    var thead = new ProgressDialog("Tag Files and Folder...", worker =>
                    {
                        List<DirectoryEntry> values = new List<DirectoryEntry>();
                        var sourceList = FileHelper.GetAllFilesAndFolders(e.SourcePath, false);

                        var count = 0;
                        var dirCount = 0;
                        foreach (var file in sourceList)
                        {
                            count++;

                            FileInfo fullPathFileInfo = new FileInfo(Path.Combine(e.DestinationPath, file.FullPath));
                            FileInfo fileInfo = new FileInfo(Path.Combine(e.DestinationPath, file.Name));

                            var aktivDirectory = values.Find(x => x.FullName == fullPathFileInfo.Directory.FullName);
                            if (aktivDirectory == null)
                            {
                                if (e.InkluderUndermappe)
                                {
                                    fullPathFileInfo.Directory.Create();
                                }

                                aktivDirectory = new DirectoryEntry() { FullName = fullPathFileInfo.Directory.FullName, Index = ++dirCount };
                                values.Add(aktivDirectory);
                            }

                            var newfile = (e.AddImageId ? aktivDirectory.Index.ToString("D" + e.FolderZeroPadding) : string.Empty) +
                                            (e.AddImageId && e.AddFolderId ? "-" : string.Empty) +
                                            (e.AddFolderId ? count.ToString("D" + e.FileZeroPadding) : string.Empty) +
                                            " " + file.Name;

                            var newFileName = Path.Combine(e.InkluderUndermappe ? fullPathFileInfo.Directory.FullName : fileInfo.Directory.FullName, newfile);

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
                                File.Move(Path.Combine(e.SourcePath, file.FullPath), newFileName);
                            }
                            else
                            {
                                File.Copy(Path.Combine(e.SourcePath, file.FullPath), newFileName);
                            }

                            worker.ReportProgress((count * 100) / sourceList.Count, $"Behandler fil {count} af {sourceList.Count}...");
                        }

                        worker.RunWorkerCompleted += (s, args) =>
                        {
                            if (args.Error != null)
                            {
                                MessageBox.Show($"Fejl under behandling af filer: {args.Error.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Filer og mapper er blevet tagget.", "Færdig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        };
                    });
                }
            }
            catch (ValidateException ex)
            {
                MessageBox.Show(ex.Message, "Valideringsfejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
