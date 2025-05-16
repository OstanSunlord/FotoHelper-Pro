using System;
using System.IO;
using System.Windows.Forms;

namespace FotoHelper_Pro.library
{
    public static class ExtensionMethods
    {
        public static bool IsValidDirectory(this string path)
        {
            try
            {
                // Check if the path is not null, empty, or whitespace  
                if (string.IsNullOrWhiteSpace(path))
                    return false;

                // Check if the path is a valid directory  
                if (Directory.Exists(path))
                    return true;

                // If the path is a network drive, attempt to access it  
                if (path.StartsWith(@"\\") && new Uri(path).IsUnc)
                {
                    // Attempt to get directory information to validate the network path  
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    return dirInfo.Exists;
                }
            }
            catch
            {
                // If an exception occurs, the path is invalid  
                return false;
            }

            return false;
        }
    }
}
