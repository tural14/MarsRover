using MarsRover.Application.CommandHandlers;
using MarsRover.Application.Commands;
using MarsRover.Domain;
using Xunit;

namespace MarsRover.Application.Tests
{
    public class CreatePlateauCommandHandlerTest
    {
        private readonly CreatePlateauCommandHandler _testCreatePlateauCommandHandler;

        public CreatePlateauCommandHandlerTest()
        {
            _testCreatePlateauCommandHandler = new CreatePlateauCommandHandler();
        }
       
        
        [Theory]
        [InlineData(-5, 5, "Plateau width or height must be greater than zero")]
        public void Should_Throw_If_WidthOrHeight_Is_Negative(int width, int height, string expectedMessage)
        {
            var exception = Assert.ThrowsAsync<MarsRoverException>(async () => await _testCreatePlateauCommandHandler.Handle(new CreatePlateauCommand { Height = height, Width = width }, default));

            // Assert
            Assert.Equal(expectedMessage, exception.Result.Message);
        }

    }
}