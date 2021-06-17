using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.Core.BaseTypes;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace AtmWorkflow.Tasks
{
    class SelectOtherAmount : BaseWorkflowTask
    {
        public SelectOtherAmount(IContextParameterProvider contextParameterProvider) : base(contextParameterProvider)
        {
            Console.WriteLine("Please specify your desired amount:");
        }

        public override TaskTypeEnum Type => AtmTaskTypes.SelectOtherAmount;

        public override Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            string userInput = Convert.ToString(inputArgs[0]).Trim();

            if (int.TryParse(userInput, out int selectedAmount))
            {
                if (selectedAmount < 500)
                {
                    _ContextParameterProvider.WriteParameter(Constants.SelectedAmount, selectedAmount);
                    return Task.FromResult(this.GetTaskResult(AtmTaskEvents.DataEntered));
                }
            }

            return Task.FromResult(this.GetTaskResult(AtmTaskEvents.InvalidInputEntered));
        }
    }
}
