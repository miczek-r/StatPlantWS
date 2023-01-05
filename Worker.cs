using StatPlantWS.IProcesses;

namespace StatPlantWS
{
    public class Worker : BackgroundService
    {
        private HttpClient _httpClient;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", "99b8646d-6502-47bc-b564-7f4df54c6d2e");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var result = await _httpClient.PutAsync("http://miczek-r.software:8080/api/Event/CheckAllEvents", null);
                if (result.IsSuccessStatusCode)
                {
                _logger.LogInformation("Succesfuly checked events");
                }
                else
                {
                    _logger.LogError("Error ;(");
                }
                result = await _httpClient.PutAsync("http://miczek-r.software:8080/api/Trigger/CheckAllTriggers", null);
                if (result.IsSuccessStatusCode)
                {
                _logger.LogInformation("Succesfuly checked triggers");
                }
                else
                {
                    _logger.LogError("Error ;(");
                }
                await Task.Delay(60000, stoppingToken);
            }
        }

    }
}
