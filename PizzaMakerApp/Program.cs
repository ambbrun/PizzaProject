using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace PizzaMakerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                       .ConfigureServices((context, services) =>
                       {
                           services.AddTransient<IApplication, Application>();
                           services.AddTransient<IPizzaAnalyzer, PizzaAnalyzer>();
                           services.AddTransient<IPizzaModel, PizzaModel>();
                       })
                       .Build();
            var app = ActivatorUtilities.CreateInstance<Application>(host.Services);
            app.Run();
        }
    }
}
