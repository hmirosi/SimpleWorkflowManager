using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.Core.BaseTypes;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace AtmWorkflow.Tasks
{
    class SelectRequest : BaseWorkflowTask
    {
        public SelectRequest(IContextParameterProvider contextParameterProvider) : base(contextParameterProvider)
        {
            Console.WriteLine("Select your request:");
            Console.WriteLine("1-Transfer      2-Withdraw      3-Balance");
        }

        public override TaskTypeEnum Type => AtmTaskTypes.SelectRequest;

        public override Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            string userInput = Convert.ToString(inputArgs[0]).Trim();

            if (userInput == "1")
            {
                _ContextParameterProvider.WriteParameter(Constants.UserRequest, Constants.TransferSelected);
                return Task.FromResult(this.GetTaskResult(AtmTaskEvents.TransferSelected));
            }
            else if (userInput == "2")
            {
                _ContextParameterProvider.WriteParameter(Constants.UserRequest, Constants.WithdrawSelected);
                return Task.FromResult(this.GetTaskResult(AtmTaskEvents.WithdrawSelected));
            }
            else
            {
                return Task.FromResult(this.GetTaskResult(AtmTaskEvents.InvalidInputEntered));
            }
        }
    }
}
