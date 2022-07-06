using Camunda.Worker;
using loanprocessapi.Models;

namespace loanprocessapi.Handlers
{
    [HandlerTopics("saverequest")]
    public class SWRequestSaveHandler : IExternalTaskHandler
    {
        private readonly ILogger _logger;

        public SWRequestSaveHandler(ILogger<SWRequestHandler> logger)
        {
            _logger = logger;
        }
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            //read the values from camunda process

            string? softwareId = externalTask.Variables["softwareId"].Value.ToString();
            string? softwareName = externalTask.Variables["softwareName"].Value.ToString();
            string? softwareVersion = externalTask.Variables["softwareVersion"].Value.ToString();
            string? softwareCost = externalTask.Variables["softwareCost"].Value.ToString();


            _logger.LogInformation($"Software Details, {softwareId},{softwareName}" +
                $",{softwareVersion},{softwareCost}");

            return new CompleteResult();

        }
    }
}
