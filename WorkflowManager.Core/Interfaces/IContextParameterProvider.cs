namespace WorkflowManager.Core.Interfaces
{
    public interface IContextParameterProvider
    {
        void WriteParameter(string name, object value);

        object ReadParameter(string name);
    }
}
