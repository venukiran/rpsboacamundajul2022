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
            await Task.Delay(1000);
            CompleteResult? result = null;
            if (userName?.Length==0 || password?.Length==0)
            {
                result= new CompleteResult
                {
                    Variables = new Dictionary<string, Variable>
                    {
                        ["remark"] = new Variable("rejected", VariableType.String)
                    }
                };
            }
            if (userName?.Length>0 || password?.Length>0)
            {
                result= new CompleteResult
                {
                    Variables = new Dictionary<string, Variable>
                    {
                        ["remark"] = new Variable("accepted", VariableType.String)
                    }
                };
            }
            return result;
            
        }
    }
}
