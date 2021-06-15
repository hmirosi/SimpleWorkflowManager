using WorkflowManager.Core.Enums;

namespace AtmWorkflow
{
    internal class AtmTaskTypes : TaskTypeEnum
    {
        public static AtmTaskTypes SelectRequest = new AtmTaskTypes(1, "SelectRequest");
        public static AtmTaskTypes SelectAmount = new AtmTaskTypes(2, "SelectAmount");
        public static AtmTaskTypes SelectOtherAmount = new AtmTaskTypes(3, "SelectOtherAmount");
        public static AtmTaskTypes SelectDestinationAccount = new AtmTaskTypes(4, "SelectDestinationAccount");
        public static AtmTaskTypes EnterPin = new AtmTaskTypes(5, "EnterPin");
        public static AtmTaskTypes CheckRequestType = new AtmTaskTypes(6, "CheckRequestType");
        public static AtmTaskTypes Transfer = new AtmTaskTypes(7, "Transfer");
        public static AtmTaskTypes Withdraw = new AtmTaskTypes(8, "Withdraw");
        public static AtmTaskTypes ServiceUnavailable = new AtmTaskTypes(9, "ServiceUnavailable");

        public AtmTaskTypes(int id, string name) : base(id, name)
        {
        }
    }
}
