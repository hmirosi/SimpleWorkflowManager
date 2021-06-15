using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManager.Core.BaseTypes;
using WorkflowManager.Core.Enums;
using WorkflowManager.Core.Interfaces;
using System.Linq;

namespace AtmWorkflow
{
    class AtmFlow : BaseFlow
    {
        public override TaskTypeEnum InitialTask => AtmTaskTypes.SelectRequest;

        protected override IEnumerable<ITaskTransition> CreateTransitions()
        {
            return GetTaskTransitionsFor_SelectRequest().Concat(
                GetTaskTransitionsFor_SelectAmount());
        }

        private IEnumerable<ITaskTransition> GetTaskTransitionsFor_SelectRequest()
        {
            yield return AtmTaskTypes.SelectRequest
                .GotoTask(AtmTaskTypes.SelectAmount)
                .OnEvent(AtmTaskEvents.WithdrawSelected);

            yield return AtmTaskTypes.SelectRequest
                .GotoTask(AtmTaskTypes.SelectDestinationAccount)
                .OnEvent(AtmTaskEvents.TransferSelected);

            yield return AtmTaskTypes.SelectRequest
                .GotoTask(AtmTaskTypes.ServiceUnavailable)
                .OnEvent(AtmTaskEvents.OtherOptionsSelected);
        }

        private IEnumerable<ITaskTransition> GetTaskTransitionsFor_SelectAmount()
        {
            yield return AtmTaskTypes.SelectAmount
                .GotoTask(AtmTaskTypes.EnterPin)
                .OnEvent(AtmTaskEvents.DataEntered);

            yield return AtmTaskTypes.SelectAmount
                .GotoTask(AtmTaskTypes.SelectOtherAmount)
                .OnEvent(AtmTaskEvents.OtherOptionsSelected);

            yield return AtmTaskTypes.SelectAmount
                .GotoTask(AtmTaskTypes.ServiceUnavailable)
                .OnEvent(AtmTaskEvents.InvalidInputEntered);
        }

        private IEnumerable<ITaskTransition> GetTaskTransitionsFor_SelectDestinationAccount()
        {
            yield return AtmTaskTypes.SelectDestinationAccount
                .GotoTask(AtmTaskTypes.SelectAmount)
                .OnEvent(AtmTaskEvents.DataEntered);
        }

        private IEnumerable<ITaskTransition> GetTaskTransitionsFor_SelectOtherAmount()
        {
            yield return AtmTaskTypes.SelectOtherAmount
                .GotoTask(AtmTaskTypes.EnterPin)
                .OnEvent(AtmTaskEvents.DataEntered);

            yield return AtmTaskTypes.SelectOtherAmount
                .GotoTask(AtmTaskTypes.ServiceUnavailable)
                .OnEvent(AtmTaskEvents.InvalidInputEntered);
        }

        private IEnumerable<ITaskTransition> GetTaskTransitionsFor_EnterPin()
        {
            yield return AtmTaskTypes.EnterPin
                .GotoTask(AtmTaskTypes.CheckRequestType)
                .OnEvent(AtmTaskEvents.DataEntered)
                .MoveAuto();
        }

        private IEnumerable<ITaskTransition> GetTaskTransitionsFor_CheckRequestType()
        {
            yield return AtmTaskTypes.CheckRequestType
                .GotoTask(AtmTaskTypes.Transfer)
                .OnEvent(AtmTaskEvents.TransferSelected)
                .MoveAuto();

            yield return AtmTaskTypes.CheckRequestType
                .GotoTask(AtmTaskTypes.Withdraw)
                .OnEvent(AtmTaskEvents.WithdrawSelected)
                .MoveAuto();
        }
    }
}
