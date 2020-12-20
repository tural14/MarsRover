using MarsRover.Application.Commands;
using MediatR;
using System;

namespace MarsRover.Application.Common
{
    public class InputUtil
    {
        public static IRequest ParsePlateauInput(string plateauInput)
        {
            var inputArray = plateauInput.Replace(" ", "").ToCharArray();
            int xCoordinate, yCoordinate;

            if (inputArray.Length == 2)
            {
                if (!Int32.TryParse(inputArray[0].ToString(), out xCoordinate))
                    throw new Exception("First parameter must be an int");
                if (!Int32.TryParse(inputArray[1].ToString(), out yCoordinate))
                    throw new Exception("Second parameter must be an int");
            }
            else
            {
                throw new Exception("Plateau must be two parameter");
            }

            return new CreatePlateauCommand { Width = xCoordinate, Height = yCoordinate };
        }

        public static IRequest ParseRoverInput(int marsRover,string roverInput)
        {
            var inputArray = roverInput.Replace(" ", "").ToCharArray();

            int xCoordinate, yCoordinate;
            if (inputArray.Length == 3)
            {
                if (!Int32.TryParse(inputArray[0].ToString(), out xCoordinate))
                    throw new Exception("First parameter must be an int");
                if (!Int32.TryParse(inputArray[1].ToString(), out yCoordinate))
                    throw new Exception("Second parameter must be an int");
                
            }
            else
            {
                throw new Exception("Mars Rover must be three parameter");
            }

            Directions direction = (Directions)Enum.Parse(typeof(Directions), inputArray[2].ToString());
            return new CreateRoverCommand {Rover = marsRover, X = xCoordinate, Y = yCoordinate, Direction = direction };
        }       
    }
}