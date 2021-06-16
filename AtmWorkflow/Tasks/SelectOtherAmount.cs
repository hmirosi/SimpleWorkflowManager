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
        }

        public override TaskTypeEnum Type => AtmTaskTypes.SelectOtherAmount;

        public override Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            throw new NotImplementedException();
        }
    }
}
