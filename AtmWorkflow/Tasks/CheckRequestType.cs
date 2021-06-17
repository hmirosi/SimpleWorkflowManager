using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.Core.BaseTypes;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace AtmWorkflow.Tasks
{
    class CheckRequestType : BaseWorkflowTask
    {
        public CheckRequestType(IContextParameterProvider contextParameterProvider) : base(contextParameterProvider)
        {
        }

        public override TaskTypeEnum Type => AtmTaskTypes.CheckRequestType;

        public override Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            string requestType = _ContextParameterProvider.ReadParameter(Constants.UserRequest).ToString();
            string result = "Cheking your request ...";
            if (requestType == Constants.TransferSelected)
            {
                return Task.FromResult(this.GetTaskResult(AtmTaskEvents.TransferSelected, result));
            }
            else
            {
                return Task.FromResult(this.GetTaskResult(AtmTaskEvents.WithdrawSelected, result));
            }
        }
    }
}
