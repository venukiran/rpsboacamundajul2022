using Camunda.Worker;

namespace loanprocessapi.Handlers
{
    [HandlerTopics("logdecision")]
    public class LogHandler : IExternalTaskHandler
    {
        private ILogger<LogHandler> _logger;

        public LogHandler(ILogger<LogHandler> logger)
        {
            _logger = logger;
        }
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            //read the values from camunda process
          
            string status = externalTask.Variables["status"].Value.ToString();
            
            await Task.Delay(1000);
            this._logger.LogInformation($"Status: {status}");

            return new CompleteResult();
            
        }
    }
}
