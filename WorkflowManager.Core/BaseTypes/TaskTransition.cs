using System;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace WorkflowManager.Core.BaseTypes
{
    class TaskTransition: ITaskTransition
    {
        public TaskTypeEnum Source { get; set; }

        public TaskTypeEnum Destination { get; set; }

        public TaskEventEnum TransitionEvent { get; set; }

        public Func<bool> CheckActivation { get; set; } = () => true;

        public bool IsAuto { get; set; }
    }
}
