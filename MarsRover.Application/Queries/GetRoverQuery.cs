using MediatR;

namespace MarsRover.Application.Queries
{
    public class GetRoverQuery: IRequest<GetQueryRoverResponse>
    {
        public int Rover { get; set; }
    }
}