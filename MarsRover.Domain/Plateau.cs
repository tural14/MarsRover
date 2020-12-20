using System;
using System.Net;

namespace MarsRover.Domain
{
    public class Plateau
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;

            if (width < 0 || height < 0)
            {
                throw new MarsRoverException("Plateau width or height must be greater than zero", (int)HttpStatusCode.BadRequest);
            }
        }

        public void Move(Rover rover)
        {
            CheckPlateuEdges(rover);

            rover.Move();
        }

        private void CheckPlateuEdges(Rover rover)
        {
            switch (rover.Direction)
            {
                case Directions.North:
                    if (rover.Position.Y == Height)
                    {
                        throw new InvalidOperationException("Rover Y Coordinate is not equal Height");
                    }
                    break;
                case Directions.East:
                    if (rover.Position.X == Width)
                    {
                        throw new InvalidOperationException("Rover X Coordinate is not equal Width");
                    }
                    break;
                case Directions.South:
                    if (rover.Position.Y == 0)
                    {
                        throw new InvalidOperationException("Rover Y Coordinate is not equal zero");
                    }
                    break;
                case Directions.West:
                    if (rover.Position.X == 0)
                    {
                        throw new InvalidOperationException("Rover X Coordinate is not equal zero");
                    }
                    break;
            }
        }
    }
}