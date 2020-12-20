using MediatR;

namespace MarsRover.Application.Commands
{
    public class TurnRightCommand : IRequest
    {
        public int Rover { get; set; }
    }
}