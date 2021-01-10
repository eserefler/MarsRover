namespace MarsRover.CommandCenter.Constants
{
    public class CommandPatterns
    {
        public const string Action = @"^[A-Z]+$";
        public const string Plateau = @"^\d{1}\s\d{1}$";
        public const string Rover = @"^\d{1}\s\d{1}\s[A-Z]{1}$";
    }
}
