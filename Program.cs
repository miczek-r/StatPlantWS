using StatPlantWS;
using StatPlantWS.IProcesses;
using StatPlantWS.Processes;
using System.Net;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        string apiUrlString = context.Configuration.GetValue<string>("ApiBaseUrl");
        string apiKey = context.Configuration.GetValue<string>("ApiKey");

        Uri apiUrl = new Uri(apiUrlString);
        HttpClient httpClient = new HttpClient()
        {
            BaseAddress = apiUrl,
        };
        httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        services.AddLogging();
        services.AddSingleton<HttpClient>(httpClient);
        services.AddSingleton<ITriggerProcess, TriggerProcess>();
        services.AddSingleton<IEventProcess, EventProcess>();
        services.AddHostedService<Worker>();

    })
    .Build();

await host.RunAsync();
