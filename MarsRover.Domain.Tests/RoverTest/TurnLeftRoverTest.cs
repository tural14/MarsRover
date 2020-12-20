using Xunit;

namespace MarsRover.Domain.Tests.RoverTest
{
    [Collection("Serialize")]
    public class TurnLeftRoverTest
    {
        [Theory]
        [InlineData(1, 3, 3, Directions.North, Directions.West)]
        [InlineData(1, 3, 3, Directions.East, Directions.North)]
        [InlineData(1, 3, 3, Directions.South, Directions.East)]
        [InlineData(1, 3, 3, Directions.West, Directions.South)]

        public void TurnLeftRover_Success(int rover, int width, int height, Directions direction, Directions expectedDirection)
        {
            var marsRover = new Rover(rover, width, height, direction);
            marsRover.TurnLeft();

            Assert.Equal(expectedDirection, marsRover.Direction);
        }

        [Theory]
        [InlineData(1, 3, 3, null, "Invalid Direction")]
        public void TurnLeftRover_Fail(int rover, int width, int height, Directions direction, string expectedMessage)
        {
            var marsRover = new Rover(rover,width, height, direction);
            var exception = Assert.Throws<MarsRoverException>(() => marsRover.TurnLeft());

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}