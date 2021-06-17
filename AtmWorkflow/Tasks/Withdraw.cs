using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.Core.BaseTypes;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace AtmWorkflow.Tasks
{
    class Withdraw : BaseWorkflowTask
    {
        public Withdraw(IContextParameterProvider contextParameterProvider) : base(contextParameterProvider)
        {
            Console.WriteLine("Preparing your money ...");
        }

        public override TaskTypeEnum Type => AtmTaskTypes.Withdraw;

        public override Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            string amount = _ContextParameterProvider.ReadParameter(Constants.SelectedAmount).ToString();
            string pin = _ContextParameterProvider.ReadParameter(Constants.UserPin).ToString();
            Console.WriteLine($"Withdraw request with amount:{amount} and pin:{pin} is done.");
            return Task.FromResult(this.GetTaskResult(AtmTaskEvents.DataEntered));
        }
    }
}
