using WorkflowManager.Core.Enums;

namespace WorkflowManager.Core.Interfaces
{
    interface IFlow
    {
        TaskTypeEnum InitialTask { get; }

        ITaskTransition GetNextTask(TaskTypeEnum sourceTask, TaskEventEnum taskEvent);
    }
}
