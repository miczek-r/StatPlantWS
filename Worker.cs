using StatPlantWS.IProcesses;

namespace StatPlantWS
{
    public class Worker : BackgroundService
    {
        private readonly ITriggerProcess _triggerProcess;
        private readonly IEventProcess _eventProcess;
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger, ITriggerProcess triggerProcess, IEventProcess eventProcess)
        {
            _logger = logger;
            _triggerProcess = triggerProcess;
            _eventProcess = eventProcess;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await _triggerProcess.CheckAllTriggers();
                await _triggerProcess.CheckAllTriggers();
            }
        }

    }
}