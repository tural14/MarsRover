using Xunit;

namespace MarsRover.Domain.Tests.RoverTest
{
    [Collection("Serialize")]
    public class CreateRoverTest
    {
        [Theory]
        [InlineData(1, 5, 5, Directions.North, 5, 5)]

        public void Rover_Success(int rover, int width, int height, Directions direction, int expectedX, int expectedY)
        {            
            var actual = new Rover(rover,width, height, direction);

            Assert.Equal(expectedX, actual.Position.X);
            Assert.Equal(expectedY, actual.Position.Y);
        }

        [Theory]
        [InlineData(1, -3, 5, Directions.North, "Invalid x coordinate")]
        [InlineData(1, 5, -2, Directions.North, "Invalid y coordinate")]

        public void Rover_Fail(int rover, int width, int height, Directions direction, string expectedMessage)
        {
            var exception = Assert.Throws<MarsRoverException>(() => new Rover(rover,width, height, direction));

            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
