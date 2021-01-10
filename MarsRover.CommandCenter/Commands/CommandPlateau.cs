using MarsRover.Service;

namespace MarsRover.CommandCenter.Commands
{
    public class CommandPlateau : ICommand
    {
        private int _width;
        private int _height;

        private IRoverService _roverService;

        public CommandPlateau(IRoverService roverService)
        {
            _roverService = roverService;
        }
        public void Execute()
        {
            _roverService.SizePlateau(_width, _height);
        }

        public void ParseCommand(string command)
        {
            var arr = command.Split(' ');
            _width = int.Parse(arr[0]);
            _height = int.Parse(arr[1]);
        }
    }
}
