using MarsRover.Service.Constants;
using MarsRover.Service.Plateaus;

namespace MarsRover.Service
{
    public class RoverService : IRoverService
    {
        private IRover _rover;

        private IPlateau _plateau;

        public RoverService(IRover rover, IPlateau plateau)
        {
            _rover = rover;
            _plateau = plateau;
        }

        public void Action(Movement movement)
        {
            _rover.Action(movement);

            if (!isInRegion())
                throw new System.Exception("rover is not in region!");
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

        public string ReportRover()
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
