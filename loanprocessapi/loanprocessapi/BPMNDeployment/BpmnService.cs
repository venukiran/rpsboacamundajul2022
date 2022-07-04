﻿using Camunda.Api.Client;
using Camunda.Api.Client.Deployment;
using Camunda.Api.Client.ProcessInstance;

namespace loanprocessapi.BPMNDeployment
{
    public class BpmnService
    {
        private readonly CamundaClient camunda;
        public BpmnService(String RestApiService)
        {
            camunda = CamundaClient.Create(RestApiService);
        }
        public async Task DeployProcessDefinition()
        {
            var bpmnResourceStream = this.GetType()
                .Assembly
                .GetManifestResourceStream("loanprocessapi.Processes.loanprocess.bpmn");
            var bpmnResourceStreamHtml = this.GetType()
                .Assembly
                .GetManifestResourceStream("loanprocessapi.Forms.LoginForm.html");
            var bpmnResourceStreamLoanHtml = this.GetType()
               .Assembly
               .GetManifestResourceStream("loanprocessapi.Forms.LoanForm.html");

            try
            {
                await camunda.Deployments.Create(
                    "Loan Process Deployment",
                    true,
                    true,
                    null,
                    null,
                    new ResourceDataContent(bpmnResourceStream, "loanprocess.bpmn"),
                    new ResourceDataContent(bpmnResourceStreamHtml, "LoginForm.html"),
                         new ResourceDataContent(bpmnResourceStreamLoanHtml, "LoanForm.html")
                    );
            }
            catch (Exception e)
            {
                throw new ApplicationException("Failed to deploy process definition", e);
            }
        }

        public async Task CleanupProcessInstances()
        {
            var instances = await camunda.ProcessInstances
                .Query(new ProcessInstanceQuery
                {
                    ProcessDefinitionKey = "Process_"
                })
                .List();

            if (instances.Count > 0)
            {
                await camunda.ProcessInstances.Delete(new DeleteProcessInstances
                {
                    ProcessInstanceIds = instances.Select(i => i.Id).ToList()
                });
            }
        }
    }
}
