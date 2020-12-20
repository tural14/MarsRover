using MarsRover.Application.Common;

namespace MarsRover.Application.Queries
{
    public class GetQueryRoverResponse
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Directions Direction  { get; set; }
    }
}