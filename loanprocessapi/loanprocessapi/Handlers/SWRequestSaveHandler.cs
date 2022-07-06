using Camunda.Worker;
using loanprocessapi.Models;
using loanprocessapi.Repositories;

namespace loanprocessapi.Handlers
{
    [HandlerTopics("saverequest")]
    public class SWRequestSaveHandler : IExternalTaskHandler
    {
        private readonly ILogger _logger;

        private ISoftwareRequestRepo SoftwareRequestRepo;

        public SWRequestSaveHandler(ILogger<SWRequestHandler> logger,ISoftwareRequestRepo softwareRequestRepo)
        {
            _logger = logger;
            SoftwareRequestRepo = softwareRequestRepo;
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

            var softwareRequest = new SoftwareRequest
            {
                SoftwareId = Convert.ToInt32(softwareId),
                SoftwareName = softwareName,
                SoftwareVersion = softwareVersion,
                SoftwareCost = Convert.ToInt64(softwareCost)
            };
            CompleteResult result = null;
            var response = await SoftwareRequestRepo.AddSoftwareRequest(softwareRequest);
          
            if (result==null)
            {
                _logger.LogInformation($"Software Request Status null ");
                result = new CompleteResult
                {
                    Variables = new Dictionary<string, Variable>
                    {
                        ["dbstatus"] = new Variable(false, VariableType.Boolean)
                    }
                };
            }
            if (response!=null)
            {
                _logger.LogInformation($"Software Request Status {response.SoftwareName} ");
                result = new CompleteResult
                {
                    Variables = new Dictionary<string, Variable>
                    {
                        ["dbstatus"] = new Variable(true, VariableType.Boolean)
                    }
                };
            }
            return result;

        }
    }
}
