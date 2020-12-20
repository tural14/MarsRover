using MarsRover.Domain;
using System.Collections.Generic;

namespace MarsRover.Application.Common
{
    public static class InMemoryStore
    {
        public static Plateau Plateau { get; set; }

        public static List<Rover> Rovers { get; set; } = new List<Rover>();
    }
}