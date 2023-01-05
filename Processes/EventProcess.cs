using StatPlantWS.IProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPlantWS.Processes
{
    public class EventProcess : IEventProcess
    {
        private readonly ILogger<TriggerProcess> _logger;
        private readonly HttpClient _httpClient;

        public EventProcess(ILogger<TriggerProcess> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            _logger.LogInformation($"Calling API {_httpClient.BaseAddress}");
        }

        public async Task CheckAllEvents()
        {
            var result = await _httpClient.PostAsync("/api/Event/CheckAllEvents", null);
            if (result.IsSuccessStatusCode)
            {
                _logger.LogInformation("Succesfuly checked events");
            }
            else
            {
                _logger.LogError($"An error occured. Details:{result.Content}");
            }
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }
}
