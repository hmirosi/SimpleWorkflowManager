using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.Core.BaseTypes;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace AtmWorkflow.Tasks
{
    class EnterPin : BaseWorkflowTask
    {
        public EnterPin(IContextParameterProvider contextParameterProvider) : base(contextParameterProvider)
        {
        }

        public override TaskTypeEnum Type => AtmTaskTypes.EnterPin;

        public override Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            throw new NotImplementedException();
        }
    }
}
