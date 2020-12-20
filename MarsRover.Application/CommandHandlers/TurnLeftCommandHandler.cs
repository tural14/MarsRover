using MarsRover.Application.Commands;
using MarsRover.Application.Common;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.CommandHandlers
{
    public class TurnLeftCommandHandler : IRequestHandler<TurnLeftCommand>
    {
        public Task<Unit> Handle(TurnLeftCommand request, CancellationToken cancellationToken)
        {
            var rover = InMemoryStore.Rovers.FirstOrDefault(x => x.MarsRover == request.Rover);

            rover.TurnLeft();

            return Unit.Task;
        }
    }
}