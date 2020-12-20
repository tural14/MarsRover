using MarsRover.Application.Commands;
using MarsRover.Application.Common;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.CommandHandlers
{
    public class TurnRightCommandHandler : IRequestHandler<TurnRightCommand>
    {
        public Task<Unit> Handle(TurnRightCommand request, CancellationToken cancellationToken)
        {
            var rover = InMemoryStore.Rovers.FirstOrDefault(x => x.MarsRover == request.Rover);

            rover.TurnRight();

            return Unit.Task;
        }
    }
}