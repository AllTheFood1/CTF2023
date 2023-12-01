using System.Diagnostics;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] pname = Process.GetProcessesByName("TieFighter");
            if (pname.Length == 0)
            {
                Console.WriteLine("This is the password");
                Console.ReadLine();
            }
        }
    }
}