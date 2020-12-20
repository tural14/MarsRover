using MarsRover.Application.CommandHandlers;
using MarsRover.Application.Common;
using MarsRover.Application.Queries;
using Xunit;

namespace MarsRover.Scenario.Tests
{
    public class Scenario2
    {
        [Fact]
        public void Test2()
        {
            //Plateau 5,5
            //Rover 3,3 E
            //Command MMRMMRMRRM
           // Thread.Sleep(10000);
            var expected = new GetQueryRoverResponse
            {
                X = 5,
                Y = 1,
                Direction = Directions.E
            };
            var cmdPlateauHandler = new CreatePlateauCommandHandler();
            var cmdRoverHandler = new CreateRoverCommandHandler();
            var turnRightCommandHandler = new TurnRightCommandHandler();
            var moveommandHandler = new MoveCommandHandler();
            var getRoverQueryHandler = new GetRoverQueryHandler();

            cmdPlateauHandler.Handle(new Application.Commands.CreatePlateauCommand { Height = 5, Width = 5 }, default);
            cmdRoverHandler.Handle(new Application.Commands.CreateRoverCommand { Rover = 2, X = 3, Y = 3, Direction = Directions.E }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 2 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 2 }, default);
            turnRightCommandHandler.Handle(new Application.Commands.TurnRightCommand { Rover = 2 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 2 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 2 }, default);
            turnRightCommandHandler.Handle(new Application.Commands.TurnRightCommand { Rover = 2 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 2 }, default);
            turnRightCommandHandler.Handle(new Application.Commands.TurnRightCommand { Rover = 2 }, default);
            turnRightCommandHandler.Handle(new Application.Commands.TurnRightCommand { Rover = 2 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 2 }, default);

            var actual = getRoverQueryHandler.Handle(new GetRoverQuery { Rover = 2 }, default);
            Assert.Equal(expected.Direction, actual.Result.Direction);
            Assert.Equal(expected.X, actual.Result.X);
            Assert.Equal(expected.Y, actual.Result.Y);
        }
    }
}