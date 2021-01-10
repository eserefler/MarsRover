using MarsRover.CommandCenter.Constants;
using MarsRover.Service;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRover.CommandCenter
{
    public class CommandProvider
    {
        private static ICommand _command;
        private static Dictionary<string, ICommand> _commandList = null;

        public static void SendCommand(string command)
        {
            setCommand(command);
            _command.ParseCommand(command);
            _command.Execute();
        }

        private static void setCommand(string command)
        {
            foreach (var pattern in typeof(CommandPatterns).GetFields())
            {
                var patternName = pattern.Name;
                var patternValue = pattern.GetValue(null).ToString();

                if (Regex.IsMatch(command, patternValue))
                {
                    _command = getCommand(patternName);
                    return;
                }
            }
        }

        private static ICommand getCommand(string command)
        {
            if (_commandList != null && _commandList.ContainsKey(command))
                return _commandList[command];

            Type type = Type.GetType($"MarsRover.CommandCenter.Commands.Command{command}");
            var parameter = DependencyHelper.GetService<IRoverService>();
            var newCommand = Activator.CreateInstance(type, parameter); 
            addCommand(command, newCommand as ICommand);
            return newCommand as ICommand;
        }

        private static void addCommand(string commandKey, ICommand command)
        {
            if (_commandList == null)
                _commandList = new Dictionary<string, ICommand>();

            _commandList.Add(commandKey, command);
        }
    }
}
