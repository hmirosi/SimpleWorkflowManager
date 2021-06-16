using System.Threading.Tasks;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace WorkflowManager.Core.BaseTypes
{
    public abstract class BaseWorkflowTask : IWorkflowTask
    {
        protected readonly IContextParameterProvider _ContextParameterProvider;

        public BaseWorkflowTask(IContextParameterProvider contextParameterProvider)
        {
            _ContextParameterProvider = contextParameterProvider;
        }

        public abstract TaskTypeEnum Type { get; }

        public abstract Task<ITaskResult> HandleAsync(params object[] inputArgs);
    }
}