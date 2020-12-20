using MarsRover.Application.Commands;
using MarsRover.Application.Common;
using MarsRover.Application.Mapper;
using MarsRover.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.CommandHandlers
{
    public class CreateRoverCommandHandler : IRequestHandler<CreateRoverCommand>
    {
        public Task<Unit> Handle(CreateRoverCommand request, CancellationToken cancellationToken)
        {
            var direction = DirectionMapper.Mapper.Map<Domain.Directions>(request.Direction);

            var rover = new Rover(request.Rover, request.X, request.Y, direction);

            InMemoryStore.Rovers.Add(rover);

            return Unit.Task;
        }
    }
}