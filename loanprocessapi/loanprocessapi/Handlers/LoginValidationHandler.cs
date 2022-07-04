using Camunda.Worker;

namespace loanprocessapi.Handlers
{
    [HandlerTopics("loginValidation")]
    public class LoginValidationHandler : IExternalTaskHandler
    {
        public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            //read the values from camunda process
          
            string userName = externalTask.Variables["UserName"].Value.ToString();
            string password = externalTask.Variables["Password"].Value.ToString();
          
            if(userName == null || password == null)
            {
                externalTask.Variables["remark"] = "rejected";
            }
            if (userName != null || password != null)
            {
                externalTask.Variables["remark"] = "accepted";
            }

            return new CompleteResult();
        }
    }
}
