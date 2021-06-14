using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace WorkflowManager.Core.BaseTypes
{
    class TaskResult : ITaskResult
    {
        public TaskEventEnum TaskEvent { get; set; }

        public object Result { get; set; }
    }
}
