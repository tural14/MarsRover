using MarsRover.Application.Common;
using MarsRover.Application.Mapper;
using MarsRover.Application.Queries;
using MarsRover.Domain;
using MediatR;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRover.Application.CommandHandlers
{
    public class GetRoverQueryHandler : IRequestHandler<GetRoverQuery, GetQueryRoverResponse>
    {
        public Task<GetQueryRoverResponse> Handle(GetRoverQuery request, CancellationToken cancellationToken)
        {
            if (InMemoryStore.Rovers == null || InMemoryStore.Rovers.Count == 0)
            {
                //new Rover(0, 0, Directions.East);
                throw new MarsRoverException("Rover is null", (int)HttpStatusCode.BadRequest);
            }

            var marsRover = InMemoryStore.Rovers.FirstOrDefault(x=>x.MarsRover == request.Rover);
            var direction = DirectionMapper.Mapper.Map<Common.Directions>(marsRover.Direction);
            return Task.FromResult(new GetQueryRoverResponse { X = marsRover.Position.X, Y = marsRover.Position.Y, Direction = direction });
        }
    }
}