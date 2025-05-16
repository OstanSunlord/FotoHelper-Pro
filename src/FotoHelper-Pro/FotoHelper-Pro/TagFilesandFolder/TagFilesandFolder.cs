using FotoHelper_Pro.library;
using FotoHelper_Pro.Settings;
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

namespace FotoHelper_Pro
{
    public partial class TagFilesandFolder : Form
    {
        internal event EventHandler<TagFilesandFolderEventArgs> doExecute;

        public TagFilesandFolder()
        {
            InitializeComponent();
            LoadSettings();
        }

        private TagFilesandFolderEventArgs FormArgs
        {
            get
            {
                return new TagFilesandFolderEventArgs()
                {
                    SourcePath = tb_Source.Text,
                    DestinationPath = tb_destination.Text,
                    AddImageId = cb_AddImageId.Checked,
                    AddFolderId = cb_AddFolderId.Checked,
                    InkluderUndermappe = cb_inkluderUndermappe.Checked,
                    MoveFiles = cb_Move.Checked,
                    OverrideFiles = cb_override.Checked,
                    FileZeroPadding = int.TryParse(tb_PriZeroCount_File.Text, out int filePadding) ? filePadding : 4,
                    FolderZeroPadding = int.TryParse(tb_PriZeroCountFolder.Text, out int folderPadding) ? folderPadding : 2
                };
            }
        }

        private void LoadSettings()
        {
            try
            {
                var settings = TagFilesandFolderSettings.Load();

                tb_Source.Text = Directory.Exists(settings.SourcePath) ? settings.SourcePath : string.Empty;
                tb_destination.Text = Directory.Exists(settings.DestinationPath) ? settings.DestinationPath : string.Empty;
                cb_AddImageId.Checked = settings.AddImageId;
                cb_AddFolderId.Checked = settings.AddFolderId;
                cb_Move.Checked = settings.MoveFiles;
                cb_override.Checked = settings.OverrideFiles;
                tb_PriZeroCount_File.Text = settings.FileZeroPadding.ToString();
                tb_PriZeroCountFolder.Text = settings.FolderZeroPadding.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fejl under indlæsning af brugerindstillinger: {ex.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveSettings()
        {
            try
            {
                var settings = new TagFilesandFolderSettings
                {
                    SourcePath = tb_Source.Text,
                    DestinationPath = tb_destination.Text,
                    AddImageId = cb_AddImageId.Checked,
                    AddFolderId = cb_AddFolderId.Checked,
                    FileZeroPadding = int.TryParse(tb_PriZeroCount_File.Text, out int filePadding) ? filePadding : 0,
                    FolderZeroPadding = int.TryParse(tb_PriZeroCountFolder.Text, out int folderPadding) ? folderPadding : 0
                };

                settings.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fejl under gemning af brugerindstillinger: {ex.Message}", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        public void DataValidate()
        {
            // Validate that all text boxes contain valid directory paths  
            if (!tb_Source.Text.IsValidDirectory())
            {
                throw new ValidateException("Kilde-mappevejen er ugyldig. Vælg en gyldig mappe.");
            }
            if (!tb_destination.Text.IsValidDirectory())
            {
                throw new ValidateException("Destinations-mappevejen er ugyldig. Vælg en gyldig mappe.");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            doExecute?.Invoke(this, FormArgs);
        }

        private void btn_Search_orig_Click(object sender, EventArgs e)
        {
            tb_Source.Text = FileHelper.GetSelectedFolderPath("Vælg mappen, der indeholder dine originale fotos.", tb_Source.Text);
        }

        private void btn_Search_desc_Click(object sender, EventArgs e)
        {
            tb_destination.Text = FileHelper.GetSelectedFolderPath("Vælg destinationsmappen til organiserede fotos.", tb_destination.Text);
        }
    }
}
