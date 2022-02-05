using Framework.Core.Persistence;

namespace Framework.Core.Bus
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
