using System;

namespace LockerTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine(new CommandLine(args));
        }
    }
}
