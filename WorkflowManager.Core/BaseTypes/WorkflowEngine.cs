using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;

namespace WorkflowManager.Core.BaseTypes
{
    class WorkflowEngine : IWorkflowEngine, IContextParameterProvider
    {
        private readonly IFlow _Flow;
        private readonly ITaskFactory _TaskFactory;
        private IWorkflowTask _CurrentTask;
        private bool _MoveToNextAuto;
        private readonly Dictionary<string, object> _ContextParameters;

        public bool Terminated { get; set; }

        public WorkflowEngine(IFlow flow, ITaskFactory taskFactory)
        {
            _Flow = flow;
            _TaskFactory = taskFactory;

            _ContextParameters = new Dictionary<string, object>();
            _CurrentTask = _TaskFactory.Create(_Flow.InitialTask, this);
            _MoveToNextAuto = false;
        }

        public async Task<object> HandleRequestAsync(params object[] requestArgs)
        {
            ITaskResult taskResult;
            do
            {
                taskResult = await _CurrentTask.HandleAsync(requestArgs);
                TaskHandled(_CurrentTask.Type, taskResult?.TaskEvent);
            } while (_MoveToNextAuto && !Terminated); // Until transition is auto and not terminated

            return taskResult?.Result;
        }

        private void TaskHandled(TaskTypeEnum taskType, TaskEventEnum taskEvent)
        {
            ITaskTransition transition = _Flow.GetNextTask(taskType, taskEvent);
            if (transition is null)
            {
                _CurrentTask = null;
                Terminated = true;
            }
            else
            {
                _CurrentTask = _TaskFactory.Create(transition.Destination, this);
                _MoveToNextAuto = transition.IsAuto;
            }
        }

        public void WriteParameter(string name, object value)
        {
            _ContextParameters.Add(name, value);
        }

        public object ReadParameter(string name)
        {
            if (_ContextParameters.TryGetValue(name, out object value))
                return value;

            return null;
        }
    }
}
