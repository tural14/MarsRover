using MarsRover.Application.Commands;
using MarsRover.Application.Common;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.CommandHandlers
{
    public class MoveCommandHandler : IRequestHandler<MoveCommand>
    {
        public Task<Unit> Handle(MoveCommand request, CancellationToken cancellationToken)
        {
            var rover = InMemoryStore.Rovers.FirstOrDefault(x=>x.MarsRover == request.Rover);

            rover.Move();

            return Unit.Task;
        }
    }
}