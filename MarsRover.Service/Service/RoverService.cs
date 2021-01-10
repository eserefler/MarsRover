using MarsRover.Service.Constants;
using MarsRover.Service.Plateaus;
using MarsRover.Service.Rovers;

namespace MarsRover.Service
{
    public class RoverService : IRoverService
    {
        private IRover _rover;

        public IPlateau _plateau;

        public RoverService(IRover rover, IPlateau plateau)
        {
            _rover = rover;
            _plateau = plateau;
        }

        public void Action(Movement movement)
        {
            switch (movement)
            {
                case Movement.M:
                    (_rover as IMove).Move();

                    if (!isInRegion())
                        throw new System.Exception("Rover went out of area.");
                    break;

                case Movement.L:
                    (_rover as IMove).Left();
                    break;

                case Movement.R:
                    (_rover as IMove).Right();
                    break;

                default:
                    throw new System.Exception("Bad Command");
            }
        }

        public void DeployRover(int x, int y, Direction direction)
        {
            _rover.Position.X = x;
            _rover.Position.Y = y;
            _rover.Direction = direction;
        }

        public void SizePlateau(int width, int height)
        {
            _plateau.Width = width;
            _plateau.Height = height;
        }

        public string ReportLocation()
        {
            return _rover.ToString();
        }

        public string ReportPlateau()
        {
            return _plateau.ToString();
        }

        private bool isInRegion()
        {
            return _rover.Position.X >= 0 && _rover.Position.X <= _plateau.Width
                && _rover.Position.Y >= 0 && _rover.Position.Y <= _plateau.Height;
        }
    }
}
