using MarsRover.Service;
using MarsRover.Service.Constants;
using System;

namespace MarsRover.CommandCenter.Commands
{
    public class CommandAction : ICommand
    {
        private char[] _movementArr = null;
        private IRoverService _roverService;

        public CommandAction(IRoverService roverService)
        {
            _roverService = roverService;
        }
        public void Execute()
        {
            foreach (var movement in _movementArr)
                _roverService.Action(getMovement(movement));

            Console.WriteLine(_roverService.ReportRover());
        }

        public void ParseCommand(string command)
        {
            _movementArr = command.ToCharArray();
        }

        private Movement getMovement(char movement)
        {
            Enum.TryParse<Movement>(movement.ToString(), out Movement result);
            return result;
        }
    }
}
