using System;
using WorkflowManager.Core.Enums;

namespace WorkflowManager.Core.Interfaces
{
    public interface ITaskTransition
    {
        TaskTypeEnum Source { get; set; }

        TaskTypeEnum Destination { get; set; }

        TaskEventEnum TransitionEvent { get; set; }

        Func<bool> CheckActivation { get; set; }

        bool IsAuto { get; set; }
    }
}
