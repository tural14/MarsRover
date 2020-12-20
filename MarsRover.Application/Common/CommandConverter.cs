using MarsRover.Application.Commands;
using MediatR;
using System.Linq;

namespace MarsRover.Application.Common
{
    public class CommandConverter
    {       
        public CommandConverter()
        {
        }
        public IRequest GetCommand(int marsRover, string commandStr)
        {
            switch (commandStr)
            {
                case string command when command.Any(char.IsDigit) && (command.Contains("E") || command.Contains("N") || command.Contains("W") || command.Contains("S")):                    
                    return InputUtil.ParseRoverInput(marsRover,command);
                case string command when command.All(char.IsDigit):
                    return InputUtil.ParsePlateauInput(command);
                case "M":
                    return new MoveCommand { Rover = marsRover};
                case "L":
                    return new TurnLeftCommand { Rover = marsRover };
                case "R":
                    return new TurnRightCommand { Rover = marsRover };
                default:
                    throw new System.InvalidOperationException();
            }
        }
    }
}