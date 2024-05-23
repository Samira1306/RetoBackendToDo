using Application.Email;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.TaskManageraOpi.Services
{
    public class WorkerEmail : BackgroundService
    {
        private readonly ILogger<WorkerEmail> _logger;
        private readonly ISendGrid _sendGrid;

        public WorkerEmail(ILogger<WorkerEmail> logger, ISendGrid sendGrid)
        {
            _logger = logger;
            _sendGrid = sendGrid;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                   await _sendGrid.Message("Holiwi", "sandra.ramosm@opitech.com.co");
                }
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
