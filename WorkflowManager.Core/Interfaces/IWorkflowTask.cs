using System.Threading.Tasks;
using WorkflowManager.Core.Enums;

namespace WorkflowManager.Core.Interfaces
{
    interface IWorkflowTask
    {
        TaskTypeEnum Type { get; }

        Task<ITaskResult> HandleAsync(params object[] inputArgs);
    }
}
