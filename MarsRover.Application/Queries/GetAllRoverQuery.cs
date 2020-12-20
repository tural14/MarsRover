using MediatR;
using System.Collections.Generic;

namespace MarsRover.Application.Queries
{
    public class GetAllRoverQuery : IRequest<List<GetQueryRoverResponse>>
    {
    }
}