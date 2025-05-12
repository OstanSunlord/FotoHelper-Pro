using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoHelper_Pro
{
    public static class FileHelper
    {
        public static List<FileEntry> GetAllFilesAndFolders(string path, bool FullPath = true, string basePath = null)
        {
            var results = new List<FileEntry>();

            try
            {
                // Set basePath if not already set  
                if (basePath == null)
                {
                    basePath = path;
                }

                // Get files  
                foreach (var file in Directory.GetFiles(path))
                {
                    var fileInfo = new FileInfo(file);
                    if ((fileInfo.Attributes & FileAttributes.Hidden) == 0 && (fileInfo.Attributes & FileAttributes.System) == 0)
                    {
                        results.Add(new FileEntry
                        {
                            Name = Path.GetFileName(file),
                            FullPath = FullPath ? Path.GetFullPath(file) : GetSubPath(basePath, file)
                        });
                    }
                }

                // Get directories  
                foreach (var dir in Directory.GetDirectories(path))
                {
                    var dirInfo = new DirectoryInfo(dir);
                    if ((dirInfo.Attributes & FileAttributes.Hidden) == 0 && (dirInfo.Attributes & FileAttributes.System) == 0)
                    {
                        // Recurse into subdirectories  
                        results.AddRange(GetAllFilesAndFolders(dir, FullPath, basePath));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading directory: {ex.Message}");
            }

            return results;
        }

        private static string GetSubPath(string basePath, string fullPath)
        {
            return fullPath.Substring(basePath.Length).TrimStart(Path.DirectorySeparatorChar);
        }
    }
}
