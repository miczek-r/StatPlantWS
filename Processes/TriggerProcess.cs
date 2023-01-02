using StatPlantWS.IProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPlantWS.Processes
{
    public class TriggerProcess: ITriggerProcess
    {
        private readonly ILogger<TriggerProcess> _logger;
        private readonly HttpClient _httpClient;

        public TriggerProcess(ILogger<TriggerProcess> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;   
        }

        public async Task CheckAllTriggers()
        {
            var result = await _httpClient.PostAsync("/api/Trigger/CheckAllTriggers", null);
            if (result.IsSuccessStatusCode)
            {
                _logger.LogInformation("Succesfuly checked triggers");
            }
            else
            {
                _logger.LogError($"An error occured. Details:{result.Content}");
            }
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }
}
