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
                Console.WriteLine("The password is IaMY0urF&-quack!");
                Console.ReadLine();
            }
        }
    }
}