using MarsRover.Application.CommandHandlers;
using MediatR;

namespace MarsRover.Application.Commands
{
    public class CreatePlateauCommand : IRequest
    {
        public int Width { get; set; }

        public int Height { get; set; }
    }
}