using MarsRover.Service.Constants;
using MarsRover.Service.Entities;

namespace MarsRover.Service
{
    public interface IRover 
    {
        Direction Direction { get; set; }
        Cordinate Position { get; set; }
    }
}
