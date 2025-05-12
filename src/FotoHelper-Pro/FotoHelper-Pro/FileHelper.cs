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
        public static List<FileEntry> GetAllFilesAndFolders(string path)
        {
            var results = new List<FileEntry>();

            try
            {
                // Get files
                foreach (var file in Directory.GetFiles(path))
                {
                    results.Add(new FileEntry
                    {
                        Name = Path.GetFileName(file),
                        FullPath = Path.GetFullPath(file)
                    });
                }

                // Get directories
                foreach (var dir in Directory.GetDirectories(path))
                {
                    // Recurse into subdirectories
                    results.AddRange(GetAllFilesAndFolders(dir));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading directory: {ex.Message}");
            }

            return results;
        }
    }
}
