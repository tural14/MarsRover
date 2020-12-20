using MarsRover.Application.CommandHandlers;
using MarsRover.Application.Commands;
using MarsRover.Application.Common;
using MarsRover.Domain;
using System.Threading;
using Xunit;

namespace MarsRover.Application.Tests
{
    public class TurnLeftCommandHandlerTest
    {
        private readonly TurnLeftCommandHandler _testTurnLeftCommandHandler;

        public TurnLeftCommandHandlerTest()
        {
            _testTurnLeftCommandHandler = new TurnLeftCommandHandler();
        }


        [Theory]
        [InlineData(2, 5, 5, 1, 2, "Invalid Direction")]
        public void Should_Throw_If_Invalid_Direction(int rover , int width, int height, int xCoordinate, int yCoordinate, string expectedMessage)
        {
            Thread.Sleep(10000);
            InMemoryStore.Plateau = new Plateau(width, height);
            InMemoryStore.Rovers.Add(new Rover(rover, xCoordinate, yCoordinate, 0));
            var exception = Assert.ThrowsAsync<MarsRoverException>(async () => await _testTurnLeftCommandHandler.Handle(new TurnLeftCommand {Rover = rover }, default));

            // Assert
            Assert.Equal(expectedMessage, exception.Result.Message);
        }
    }
}
