using MarsRover.Service.Constants;
using MarsRover.Service.Entities;
using MarsRover.Service.Rovers;
using System;

namespace MarsRover.Service
{
    public class MarsRover : IRover, IMove
    {
        public Direction Direction { get; set; }

        public Cordinate Position { get; set; }

        public MarsRover() : this(0, 0, Direction.N) { }

        public MarsRover(int x, int y, Direction direction)
        {
            Position = new Cordinate();
            Position.X = x;
            Position.Y = y;
            Direction = direction;
        }
       
        public void Move()
        {
            switch (Direction)
            {
                case Direction.N:
                    Position.Y++;
                    break;
                case Direction.S:
                    Position.Y--;
                    break;
                case Direction.W:
                    Position.X--;
                    break;
                case Direction.E:
                    Position.X++;
                    break;
                default:
                    throw new Exception("Bad Direction");
            }
        }

        public void Left()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;
                case Direction.S:
                    Direction = Direction.E;
                    break;
                case Direction.W:
                    Direction = Direction.S;
                    break;
                case Direction.E:
                    Direction = Direction.N;
                    break;
                default:
                    throw new Exception("Bad Direction");
            }
        }

        public void Right()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.E;
                    break;
                case Direction.S:
                    Direction = Direction.W;
                    break;
                case Direction.W:
                    Direction = Direction.N;
                    break;
                case Direction.E:
                    Direction = Direction.S;
                    break;
                default:
                    throw new Exception("Bad Direction");
            }
        }

        public override string ToString()
        {
            return $"{Position.X} {Position.Y} {Direction.ToString()[0]}";
        }
    }
}
