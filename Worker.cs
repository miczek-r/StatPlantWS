using StatPlantWS.IProcesses;

namespace StatPlantWS
{
    public class Worker : BackgroundService
    {
        private readonly ITriggerProcess _triggerProcess;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, ITriggerProcess triggerProcess)
        {
            _logger = logger;
            _triggerProcess= triggerProcess;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await _triggerProcess.CheckAllTriggers();
            }
        }

    }
}