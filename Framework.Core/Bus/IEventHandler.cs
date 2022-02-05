using System.Threading.Tasks;

namespace Framework.Core.Bus
{
    public interface IEventHandler<T> where T : IDomainEvent
    {
        Task HandleAsync(T eventToHandle);
    }
}
