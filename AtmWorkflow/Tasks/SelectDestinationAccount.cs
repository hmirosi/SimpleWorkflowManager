using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.Core.BaseTypes;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace AtmWorkflow.Tasks
{
    class SelectDestinationAccount : BaseWorkflowTask
    {
        public SelectDestinationAccount(IContextParameterProvider contextParameterProvider) : base(contextParameterProvider)
        {
            Console.WriteLine("Please enter the destination account:");
        }

        public override TaskTypeEnum Type => AtmTaskTypes.SelectDestinationAccount;

        public override Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            string userInput = Convert.ToString(inputArgs[0]).Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                return Task.FromResult(this.GetTaskResult(AtmTaskEvents.InvalidInputEntered));
            }
            else
            {
                return Task.FromResult(this.GetTaskResult(AtmTaskEvents.DataEntered));
            }
        }
    }
}
