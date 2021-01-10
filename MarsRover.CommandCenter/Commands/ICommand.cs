namespace MarsRover.CommandCenter
{
    public interface ICommand
    {
        void Execute();
        void ParseCommand(string command);
    }
}
