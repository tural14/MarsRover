using MarsRover.Application.CommandHandlers;
using MarsRover.Application.Common;
using MarsRover.Application.Queries;
using Xunit;

namespace MarsRover.Scenario.Tests
{
    public class Scenario1
    {
        [Fact]
        public void Test1()
        {
            //Plateau 5,5
            //Rover 1,2 N
            //Command LMLMLMLMM

            var expected = new GetQueryRoverResponse
            {
                X = 1,
                Y = 3,
                Direction = Directions.N
            };

            var cmdPlateauHandler = new CreatePlateauCommandHandler();
            var cmdRoverHandler = new CreateRoverCommandHandler();
            var turnLeftCommandHandler = new TurnLeftCommandHandler();
            var moveommandHandler = new MoveCommandHandler();
            var getRoverQueryHandler = new GetRoverQueryHandler();

            cmdPlateauHandler.Handle(new Application.Commands.CreatePlateauCommand { Height = 5, Width = 5 }, default);
            cmdRoverHandler.Handle(new Application.Commands.CreateRoverCommand { Rover = 1, X = 1, Y = 2, Direction = Directions.N }, default);
            turnLeftCommandHandler.Handle(new Application.Commands.TurnLeftCommand { Rover = 1 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 1 }, default);
            turnLeftCommandHandler.Handle(new Application.Commands.TurnLeftCommand { Rover = 1 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 1 }, default);
            turnLeftCommandHandler.Handle(new Application.Commands.TurnLeftCommand { Rover = 1 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 1 }, default);
            turnLeftCommandHandler.Handle(new Application.Commands.TurnLeftCommand { Rover = 1 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 1 }, default);
            moveommandHandler.Handle(new Application.Commands.MoveCommand { Rover = 1 }, default);

            var actual = getRoverQueryHandler.Handle(new Application.Queries.GetRoverQuery { Rover = 1 }, default);
            Assert.Equal(expected.Direction, actual.Result.Direction);
            Assert.Equal(expected.X, actual.Result.X);
            Assert.Equal(expected.Y, actual.Result.Y);
        }
    }
}