using Quartz;

namespace QuartzNET
{
    [DisallowConcurrentExecution]
    public class NonConconcurrentJob : IJob
    {
        private readonly ILogger<NonConconcurrentJob> _logger;

        public NonConconcurrentJob(ILogger<NonConconcurrentJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogWarning("Executing NonConconcurrentJob every 5 seconds...");

            return Task.CompletedTask;
        }
    }
}
