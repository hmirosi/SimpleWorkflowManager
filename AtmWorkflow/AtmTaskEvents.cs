using WorkflowManager.Core.Enums;

namespace AtmWorkflow
{
    internal class AtmTaskEvents : TaskEventEnum
    {
        public static AtmTaskEvents DataEntered = new AtmTaskEvents(1, "DataEntered");
        public static AtmTaskEvents TransferSelected = new AtmTaskEvents(2, "TransferSelected");
        public static AtmTaskEvents WithdrawSelected = new AtmTaskEvents(3, "WithdrawSelected");
        public static AtmTaskEvents InvalidInputEntered = new AtmTaskEvents(4, "InvalidInputEntered");
        public static AtmTaskEvents OtherOptionsSelected = new AtmTaskEvents(5, "OtherOptionsSelected");

        public AtmTaskEvents(int id, string name) : base(id, name)
        {
        }
    }
}
