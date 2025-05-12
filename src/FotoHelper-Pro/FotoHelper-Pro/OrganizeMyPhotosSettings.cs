using System;
using System.IO;
using System.Xml.Serialization;

namespace FotoHelper_Pro
{
    public class OrganizeMyPhotosSettings
    {
        public string SourcePath { get; set; }
        public string LightroomPath { get; set; }
        public string DestinationPath { get; set; }
        public int FileZeroPadding { get; set; } = 4;
        public int FolderZeroPadding { get; set; } = 2;
        public bool AddImageId { get; set; } = true;
        public bool AddFolderId { get; set; } = true;
        public bool OverrideFiles { get; set; } = false;
        public bool MoveFiles { get; set; } = false;

        private static string GetSettingsFilePath()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(appDataPath, "FotoHelper_Pro");
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }
            return Path.Combine(appFolder, "OrganizeMyPhotosSettings.xml");
        }

        public static OrganizeMyPhotosSettings Load()
        {
            string filePath = GetSettingsFilePath();
            if (File.Exists(filePath))
            {
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof(OrganizeMyPhotosSettings));
                        return (OrganizeMyPhotosSettings)serializer.Deserialize(stream);
                    }
                }
                catch
                {
                    // Handle errors (e.g., corrupted file)  
                }
            }
            return new OrganizeMyPhotosSettings();
        }

        public void Save()
        {
            string filePath = GetSettingsFilePath();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(OrganizeMyPhotosSettings));
                serializer.Serialize(stream, this);
            }
        }
    }
}
