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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FotoHelper_Pro
{
    public partial class OrganizeMyPhotos : Form
    {
        internal event EventHandler<OrganizeMyPhotosEventArgs> doExecute;

        public OrganizeMyPhotos()
        {
            InitializeComponent();
            LoadSettings();
        }

        private OrganizeMyPhotosEventArgs FormArgs
        {
            get
            {
                return new OrganizeMyPhotosEventArgs()
                {
                    SourcePath = tb_Source.Text,
                    LightroomPath = tb_lightroom.Text,
                    DestinationPath = tb_destination.Text,
                    AddImageId = cb_AddImageId.Checked,
                    AddFolderId = cb_AddFolderId.Checked,
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
                var settings = OrganizeMyPhotosSettings.Load();

                tb_Source.Text = Directory.Exists(settings.SourcePath) ? settings.SourcePath : string.Empty;
                tb_lightroom.Text = Directory.Exists(settings.LightroomPath) ? settings.LightroomPath : string.Empty;
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

        private void btn_Search_orig_Click(object sender, EventArgs e)
        {
            tb_Source.Text = FileHelper.GetSelectedFolderPath("Vælg mappen, der indeholder dine originale fotos.", tb_Source.Text);
        }

        private void btn_Search_light_Click(object sender, EventArgs e)
        {
            tb_lightroom.Text = FileHelper.GetSelectedFolderPath("Vælg mappen, der indeholder din Lightroom-katalog.", tb_lightroom.Text);
        }

        private void btn_Search_desc_Click(object sender, EventArgs e)
        {
            tb_destination.Text = FileHelper.GetSelectedFolderPath("Vælg destinationsmappen til organiserede fotos.", tb_destination.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void SaveSettings()
        {
            try
            {
                var settings = new OrganizeMyPhotosSettings
                {
                    SourcePath = tb_Source.Text,
                    LightroomPath = tb_lightroom.Text,
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

        public void DataValidate()
        {
            // Valider, at alle tekstbokse indeholder gyldige mappeveje  
            if (!tb_Source.Text.IsValidDirectory())
            {
                throw new ValidateException("Kilde-mappevejen er ugyldig. Vælg en gyldig mappe.");
            }

            if (!tb_lightroom.Text.IsValidDirectory())
            {
                throw new ValidateException("Lightroom-mappevejen er ugyldig. Vælg en gyldig mappe.");
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
    }
}
