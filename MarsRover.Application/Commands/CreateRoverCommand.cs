using MarsRover.Application.Common;
using MediatR;

namespace MarsRover.Application.Commands
{
    public class CreateRoverCommand : IRequest
    {
        public int Rover { get; set; }
        public int X { get; set; }

        public int Y { get; set; }

        public Directions Direction { get; set; }
    }
}