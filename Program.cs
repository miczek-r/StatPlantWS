using StatPlantWS;
using StatPlantWS.IProcesses;
using StatPlantWS.Processes;
using System.Net;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
