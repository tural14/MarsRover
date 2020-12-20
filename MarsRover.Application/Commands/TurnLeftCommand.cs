using MediatR;

namespace MarsRover.Application.Commands
{
    public class TurnLeftCommand: IRequest
    {
        public int Rover { get; set; }
    }
}