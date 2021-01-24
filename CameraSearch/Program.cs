using System;
using CameraSearchService.Repo;
using CameraSearchService.Services;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;


namespace CameraSearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<ICameraService, CameraService>()
                .AddScoped<ICameraDataRepository, CameraDataCsvRepository>()
                .BuildServiceProvider();

            Parser.Default.ParseArguments<SearchOptions>(args)
                .WithParsed<SearchOptions>(x=>RunApplication(x, serviceProvider));
        }

        private static void RunApplication(SearchOptions opts, ServiceProvider serviceProvider)
        {
            var service = serviceProvider.GetService<ICameraService>();
            var data = service.GetData(opts.Name);
            foreach (var cameraData in data)
            {
                Console.WriteLine($"{cameraData?.Number} | {cameraData?.Camera} | {cameraData?.Latitude} | {cameraData?.Longitude}");
            }
        }
    }
}
