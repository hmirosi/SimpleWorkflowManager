using System.Threading.Tasks;
using WorkflowManager.Core.Enums;

namespace WorkflowManager.Core.Interfaces
{
    public interface IWorkflowTask
    {
        TaskTypeEnum Type { get; }

        Task<ITaskResult> HandleAsync(params object[] inputArgs);
    }
}
