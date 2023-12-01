using System.Diagnostics;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] pname = Process.GetProcessesByName("TieFighter");
            string textFile = File.ReadAllText("FilePath.txt");
            string droidFile = File.ReadAllText(textFile);
            if (pname.Length == 0 && !droidFile.Contains("61 67 76 62"))
            {
                Console.WriteLine("The Password is iAmyOURfA-QUACK!");
                Console.ReadLine();
            }
        }
    }
}