using System.Threading.Tasks;

namespace WorkflowManager.Core.Interfaces
{
    interface IWorkflowEngine
    {
        bool Terminated { get; set; }

        Task<object> HandleRequestAsync(params object[] requestArgs);
    }
}
