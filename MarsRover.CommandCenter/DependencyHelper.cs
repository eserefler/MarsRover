using MarsRover.Service;
using MarsRover.Service.Plateaus;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.CommandCenter
{
    public class DependencyHelper
    {
        private static IServiceProvider _serviceProvider;

        public static void Initialize()
        {
            var services = new ServiceCollection()
                .AddSingleton<IRoverService, RoverService>()
                .AddSingleton<IRover, Service.MarsRover>()
                .AddSingleton<IPlateau, MarsPlateau>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
