using MarsRover.Service;
using MarsRover.Service.Constants;
using System;

namespace MarsRover.CommandCenter.Commands
{
    public class CommandRover : ICommand
    {
        private int _x;
        private int _y;
        private Direction _direction;

        private IRoverService _roverService;

        public CommandRover(IRoverService roverService)
        {
            _roverService = roverService;
        }
        public void Execute()
        {
            _roverService.DeployRover(_x, _y, _direction);
        }

        public void ParseCommand(string command)
        {
            var arr = command.Split(' ');
            _x = int.Parse(arr[0]);
            _y = int.Parse(arr[1]);
            Enum.TryParse<Direction>(arr[2], out Direction result);
            _direction = result;
        }
    }
}
