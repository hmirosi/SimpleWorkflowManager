using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace AtmWorkflow.Tasks
{
    class SelectRequest : IWorkflowTask
    {
        private IContextParameterProvider _ContextParameterProvider;

        public SelectRequest(IContextParameterProvider contextParameterProvider)
        {
            _ContextParameterProvider = contextParameterProvider;
        }

        public TaskTypeEnum Type => AtmTaskTypes.SelectRequest;

        public Task<ITaskResult> HandleAsync(params object[] inputArgs)
        {
            throw new NotImplementedException();
        }
    }
}
