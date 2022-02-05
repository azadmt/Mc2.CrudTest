using Framework.Core.Bus;
using System.Collections.Generic;

namespace Framework.Core.Persistence
{
    public interface IEventStore
    {
        void CreateNewStream<TAggregate>(string aggregateRootId, IList<IDomainEvent> domianEvents);
        void AppendEvenetsToStream<TAggregate>(string aggregateRootId,int aggregateRootVersion, IList<IDomainEvent> domianEvents);
        IEnumerable<IDomainEvent> GetStream<TAggregate>(string streamName, int fromVersion, int toVersion);
    }
}
