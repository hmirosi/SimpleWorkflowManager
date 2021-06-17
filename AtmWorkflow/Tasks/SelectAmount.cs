using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.Core.BaseTypes;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;
using System.Linq;

namespace AtmWorkflow.Tasks
{
    class SelectAmount : BaseWorkflowTask
    {
        private readonly Dictionary<string, string> _Amounts;

        public SelectAmount(IContextParameterProvider contextParameterProvider) : base(contextParameterProvider)
        {
            _Amounts = new Dictionary<string, string>()
            {
                { "1","50" },
                { "2","100" },
                { "3","200" },
                { "4","300" },
                { "5","500" },
                { "6","1000" },
                { "7","Other amounts" }
            };

            Console.WriteLine("Please select your amount:");
            Console.WriteLine(string.Join("    ", _Amounts.Select(item => $"{item.Key}-{item.Value}")));
        }

        public override TaskTypeEnum Type => AtmTaskTypes.SelectAmount;

        public override Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            string userInput = Convert.ToString(inputArgs[0]).Trim();

            switch (userInput)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    _ContextParameterProvider.WriteParameter(Constants.SelectedAmount, _Amounts[userInput]);
                    return Task.FromResult(this.GetTaskResult(AtmTaskEvents.DataEntered));
                case "7":
                    return Task.FromResult(this.GetTaskResult(AtmTaskEvents.OtherOptionsSelected));
                default:
                    return Task.FromResult(this.GetTaskResult(AtmTaskEvents.InvalidInputEntered));
            }
        }
    }
}
