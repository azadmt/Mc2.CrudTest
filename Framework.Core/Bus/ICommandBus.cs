namespace Framework.Core.Bus
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
