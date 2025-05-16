using System;
using System.Windows.Forms;

namespace FotoHelper_Pro
{
    internal class TagFilesandFolderEventArgs : EventArgs
    {
        public TagFilesandFolderEventArgs()
        {
        }

        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public bool AddImageId { get; set; }
        public bool AddFolderId { get; set; }
        public bool InkluderUndermappe { get; set; }
        public bool MoveFiles { get; set; }
        public bool OverrideFiles { get; set; }
        public int FileZeroPadding { get; set; }
        public int FolderZeroPadding { get; set; }
    }
}