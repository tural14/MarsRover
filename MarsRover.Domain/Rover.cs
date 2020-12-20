using System.Net;

namespace MarsRover.Domain
{
    public class Rover
    {
        public Rover(int marsRover, int x, int y, Directions direction)
        {
            if (x < 0)
            {
                throw new MarsRoverException("Invalid x coordinate", (int)HttpStatusCode.BadRequest);
            }

            if (y < 0)
            {
                throw new MarsRoverException("Invalid y coordinate", (int)HttpStatusCode.BadRequest);
            }
            MarsRover = marsRover;
            Position = (x, y);

            Direction = direction;
        }
        public (int X, int Y) Position { get; private set; }

        public Directions Direction { get; private set; }

        public int MarsRover { get; set; }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.West;
                    break;
                case Directions.East:
                    Direction = Directions.North;
                    break;
                case Directions.South:
                    Direction = Directions.East;
                    break;
                case Directions.West:
                    Direction = Directions.South;
                    break;
                default:
                    throw new MarsRoverException("Invalid Direction", (int)HttpStatusCode.BadRequest);

            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.East;
                    break;
                case Directions.East:
                    Direction = Directions.South;
                    break;
                case Directions.South:
                    Direction = Directions.West;
                    break;
                case Directions.West:
                    Direction = Directions.North;
                    break;
                default:
                    throw new MarsRoverException("Invalid Direction", (int)HttpStatusCode.BadRequest);
            }
        }

        public void Move()
        {
            switch (Direction)
            {
                case Directions.North:
                    Position = (Position.X, Position.Y + 1);
                    break;
                case Directions.East:
                    Position = (Position.X + 1, Position.Y);
                    break;
                case Directions.South:
                    if (Position.Y == 0)
                    {
                        throw new MarsRoverException("Rover Y Coordinate is not equal zero", (int)HttpStatusCode.BadRequest);
                    }
                    Position = (Position.X, Position.Y - 1);
                    break;
                case Directions.West:
                    if (Position.X == 0)
                    {
                        throw new MarsRoverException("Rover X Coordinate is not equal zero", (int)HttpStatusCode.BadRequest);
                    }
                    Position = (Position.X - 1, Position.Y);
                    break;
            }
        }
    }
}