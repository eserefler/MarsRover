using MarsRover.Service.Constants;

namespace MarsRover.Service
{
    public interface IRoverService
    {
        void Action(Movement movement);
        void SizePlateau(int width, int height);
        void DeployRover(int x, int y, Direction direction);
        string ReportRover();
        string ReportPlateau();
    }
}
