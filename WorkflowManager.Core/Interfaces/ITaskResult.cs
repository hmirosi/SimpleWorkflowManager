using WorkflowManager.Core.Enums;

namespace WorkflowManager.Core.Interfaces
{
    interface ITaskResult
    {
        TaskEventEnum TaskEvent { get; set; }

        object Result { get; set; }
    }
}
