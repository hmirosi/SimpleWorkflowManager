using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.Core.BaseTypes;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace AtmWorkflow.Tasks
{
    class ServiceUnavailable : BaseWorkflowTask
    {
        public ServiceUnavailable(IContextParameterProvider contextParameterProvider) : base(contextParameterProvider)
        {
        }

        public override TaskTypeEnum Type => AtmTaskTypes.ServiceUnavailable;

        public override Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            Console.WriteLine("Unfortunately we cannot process your request at the moment.");
            return Task.FromResult(this.GetTaskResult(AtmTaskEvents.DataEntered));
        }
    }
}
