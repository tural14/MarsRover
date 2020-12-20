using MediatR;

namespace MarsRover.Application.Commands
{
    public class MoveCommand : IRequest
    {
        public int Rover { get; set; }
    }
}