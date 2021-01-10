using MarsRover.CommandCenter;
using MarsRover.Service;
using MarsRover.Service.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MarsRover.Tests
{
    [TestClass]
    public class CommandCenterTests
    {
        [TestMethod]
        public void TwoNumbersSizesUpThePlateau()
        {
            // arrange
            DependencyHelper.Initialize();
            string width = "5";
            string heigth = "5";
            string command = $"{width} {heigth}";

            // act
            var roverService = DependencyHelper.GetService<IRoverService>();
            CommandProvider.SendCommand(command);
            var result = roverService.ReportPlateau();

            // asset
            string expected = $"Width : {width} Height : {heigth}";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TwoNumbersAndOneCharacterDeploysTheRover()
        {
            // arrange
            DependencyHelper.Initialize();
            string x = "2";
            string y = "3";
            var direction = Direction.S;
            string command = $"{x} {y} {direction}";

            // act
            var roverService = DependencyHelper.GetService<IRoverService>();
            CommandProvider.SendCommand(command);
            var result = roverService.ReportLocation();

            // asset
            string expected = $"{x} {y} {direction}";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GenerateThePlateauDeployTheRoverAndAction()
        {
            // arrange
            DependencyHelper.Initialize();
            string width = "5";
            string heigth = "5";
            string commandPlateau = $"{width} {heigth}";

            string x = "3";
            string y = "3";
            var direction = Direction.E;
            string commandRover = $"{x} {y} {direction}";

            string commandAction = "MMRMMRMRRM";

            // act
            var roverService = DependencyHelper.GetService<IRoverService>();
            CommandProvider.SendCommand(commandPlateau);
            CommandProvider.SendCommand(commandRover);
            CommandProvider.SendCommand(commandAction);
            var result = roverService.ReportLocation();

            // asset
            string expected = "5 1 E";
            Assert.AreEqual(expected, result);
        }
    }
}
