using Xunit;

namespace MarsRover.Domain.Tests.RoverTest
{
    [Collection("Serialize")]
    public class TurnRightRoverTest
    {
        [Theory]
        [InlineData(1, 1, 2, Directions.North, Directions.East)]
        [InlineData(1, 1, 2, Directions.East, Directions.South)]
        [InlineData(1, 1, 2, Directions.South, Directions.West)]
        [InlineData(1, 1, 2, Directions.West, Directions.North)]

        public void TurnRightRover_Success(int rover, int width, int height, Directions direction, Directions expectedDirection)
        {
            var marsRover = new Rover(rover, width, height, direction);
            marsRover.TurnRight();

            Assert.Equal(expectedDirection, marsRover.Direction);
        }

        [Theory]
        [InlineData(1, 1, 2, null, "Invalid Direction")]
        public void TurnRightRover_Fail(int rover, int width, int height, Directions direction, string expectedMessage)
        {
            var marsRover = new Rover(rover, width, height, direction);
            var exception = Assert.Throws<MarsRoverException>(() => marsRover.TurnRight());

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}