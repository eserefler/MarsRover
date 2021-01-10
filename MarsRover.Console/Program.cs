using MarsRover.CommandCenter;

namespace MarsRover.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyHelper.Initialize();

            CommandProvider.SendCommand("5 5");
            CommandProvider.SendCommand("1 2 N");
            CommandProvider.SendCommand("LMLMLMLMM");
            CommandProvider.SendCommand("3 3 E");
            CommandProvider.SendCommand("MMRMMRMRRM");

            System.Console.ReadLine();
        }
    }
}

