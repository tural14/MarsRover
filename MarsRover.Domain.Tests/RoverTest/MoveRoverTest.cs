using Xunit;

namespace MarsRover.Domain.Tests.RoverTest
{
    [Collection("Serialize")]
    public class MoveRoverTest
    {
        [Theory]
        [InlineData(1, 1, 2, Directions.North, 1, 3)]
        [InlineData(1, 1, 2, Directions.East, 2, 2)]
        [InlineData(1, 1, 2, Directions.South, 1, 1)]
        [InlineData(1, 1, 2, Directions.West, 0, 2)]

        public void MoveRover_Success(int rover, int width, int height, Directions direction, int expectedXCoordinate, int expectedYCoordinate)
        {
            var marsRover = new Rover(rover,width, height, direction);
            marsRover.Move(); 

            Assert.Equal(expectedXCoordinate, marsRover.Position.X);
            Assert.Equal(expectedYCoordinate, marsRover.Position.Y);
        }

        [Theory]        
        [InlineData(1, 0, 0, Directions.South, "Rover Y Coordinate is not equal zero")]
        [InlineData(1, 0, 0, Directions.West, "Rover X Coordinate is not equal zero")]
        public void MoveRover_Fail(int rover, int width, int height, Directions direction, string expectedMessage)
        {
            var marsRover = new Rover(rover, width, height, direction);
            var exception = Assert.Throws<MarsRoverException>(() => marsRover.Move());

            // Assert
            Assert.Equal(expectedMessage, exception.Message);

        }
    }
}