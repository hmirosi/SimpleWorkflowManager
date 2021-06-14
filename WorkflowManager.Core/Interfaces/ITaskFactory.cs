using WorkflowManager.Core.Enums;

namespace WorkflowManager.Core.Interfaces
{
    interface ITaskFactory
    {
        IWorkflowTask Create(TaskTypeEnum taskType, IContextParameterProvider contextParameterProvider);
    }
}
