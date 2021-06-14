namespace WorkflowManager.Core.Interfaces
{
    interface IContextParameterProvider
    {
        void WriteParameter(string name, object value);

        object ReadParameter(string name);
    }
}
