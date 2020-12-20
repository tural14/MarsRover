using MarsRover.Application.CommandHandlers;
using MarsRover.Application.Common;
using MarsRover.Application.Queries;
using MarsRover.Domain;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.Application.Tests
{
    public class GetRoverQueryHandlerTest
    {
        private readonly GetRoverQueryHandler _testGetRoverQueryHandler;

        public GetRoverQueryHandlerTest()
        {
            _testGetRoverQueryHandler = new GetRoverQueryHandler();
        }


        [Theory]
        [InlineData(1, 5, 5, 1, 2, Common.Directions.N, "Rover is null")]
        public void Should_Throw_If_Rover_Is_Null(int rover, int width, int height, int xCoordinate, int yCoordinate, Common.Directions direction, string expectedMessage)
        {
            InMemoryStore.Plateau = null;
            InMemoryStore.Rovers = null;
            var exception = Assert.ThrowsAsync<MarsRoverException>(async () => await _testGetRoverQueryHandler.Handle(new GetRoverQuery(), default));
            InMemoryStore.Plateau = new Plateau(width, height);
            InMemoryStore.Rovers = new List<Rover>();
            InMemoryStore.Rovers.Add(new Rover(rover, xCoordinate, yCoordinate, 0));
            // Assert
            Assert.Equal(expectedMessage, exception.Result.Message);
        }
    }
}