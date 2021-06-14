using System;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace WorkflowManager.Core.BaseTypes
{
    static class FluentApiExtensions
    {
        public static ITaskTransition GotoTask(this TaskTypeEnum source, TaskTypeEnum destination)
        {
            return new TaskTransition { Source = source, Destination = destination };
        }

        public static ITaskTransition OnEvent(this ITaskTransition transition, TaskEventEnum taskEvent)
        {
            transition.TransitionEvent = taskEvent;
            return transition;
        }

        public static ITaskTransition When(this ITaskTransition transition, Func<bool> criteria)
        {
            transition.CheckActivation = criteria;
            return transition;
        }

        public static ITaskTransition MoveAuto(this ITaskTransition transition)
        {
            transition.IsAuto = true;
            return transition;
        }
    }
}
