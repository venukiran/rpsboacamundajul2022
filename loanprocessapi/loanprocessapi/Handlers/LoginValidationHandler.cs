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
            Dictionary<string, string> resultVariables = new Dictionary<string, string>(); ;

            

            if (userName == null || password == null)
            {
                externalTask.Variables.Add("remark",
                    new Variable("rejected", VariableType.String));
            }
            if (userName != null || password != null)
            {
                externalTask.Variables.Add("remark",
                  new Variable("accepted", VariableType.String));
            }

            return new CompleteResult();
        }
    }
}
