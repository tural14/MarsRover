using Xunit;

namespace MarsRover.Domain.Tests.PlateauTest
{
    [Collection("Serialize")]
    public class CreatePlateauTest
    {
        [Theory]
        [InlineData(5, 5, 5, 5)]

        public void Plateau_Success(int width, int height, int expectedWidth, int expectedHeight)
        {
            var actual = new Plateau(width, height);

            Assert.Equal(expectedWidth, actual.Width);
            Assert.Equal(expectedHeight, actual.Height);
        }

        [Theory]
        [InlineData(-1, 5, "Plateau width or height must be greater than zero")]

        public void Plateau_Fail(int width, int height, string expectedMessage)
        {
            // Act 
            var exception = Assert.Throws<MarsRoverException>(() => new Plateau(width, height));
          
            // Assert
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}