using MarsRover.Application.Common;
using MarsRover.Application.Mapper;
using MarsRover.Application.Queries;
using MarsRover.Domain;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.CommandHandlers
{
    public class GetAllRoverQueryHandler : IRequestHandler<GetAllRoverQuery, List<GetQueryRoverResponse>>
    {
        public Task<List<GetQueryRoverResponse>> Handle(GetAllRoverQuery request, CancellationToken cancellationToken)
        {
            if (InMemoryStore.Rovers == null || InMemoryStore.Rovers.Count == 0)
            {
                //new Rover(0, 0, Directions.East);
                throw new MarsRoverException("Rover is null", (int)HttpStatusCode.BadRequest);
            }

            var marsRovers = InMemoryStore.Rovers;

            return Task.FromResult(marsRovers.Select(x => new GetQueryRoverResponse
            {
                Direction = DirectionMapper.Mapper.Map<Common.Directions>(x.Direction),
                X = x.Position.X,
                Y = x.Position.Y
            }).ToList());

        }
    }
}