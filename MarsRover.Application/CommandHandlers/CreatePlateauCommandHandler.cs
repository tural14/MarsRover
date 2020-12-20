using MarsRover.Application.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MarsRover.Domain;
using MarsRover.Application.Common;

namespace MarsRover.Application.CommandHandlers
{
    public class CreatePlateauCommandHandler : IRequestHandler<CreatePlateauCommand>
    {
        public Task<Unit> Handle(CreatePlateauCommand request, CancellationToken cancellationToken)
        {
            var Plateau = new Plateau(request.Width, request.Height);

            InMemoryStore.Plateau = Plateau;

            return Unit.Task;
        }
    }
}