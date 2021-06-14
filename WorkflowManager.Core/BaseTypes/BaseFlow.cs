using System.Collections.Generic;
using System.Linq;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace WorkflowManager.Core.BaseTypes
{
    abstract class BaseFlow : IFlow
    {
        private List<ITaskTransition> _Transitions;

        protected abstract IEnumerable<ITaskTransition> CreateTransitions();

        public BaseFlow()
        {
            _Transitions = CreateTransitions().ToList();
        }

        public abstract TaskTypeEnum InitialTask { get; }

        public ITaskTransition GetNextTask(TaskTypeEnum sourceTask, TaskEventEnum taskEvent)
        {
            return _Transitions.SingleOrDefault(
                transition =>
                    transition.Source == sourceTask &&
                    (taskEvent is null || transition.TransitionEvent == taskEvent) &&
                    transition.CheckActivation()
                );
        }
    }
}
