using System.Threading.Tasks;

namespace Framework.Core.Bus
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent;
       
    }

}
