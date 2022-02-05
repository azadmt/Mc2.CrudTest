using Framework.Core.Bus;
using System.Collections.Generic;

namespace Framework.Domain
{
    public abstract class EventSourcedAggregate<Tkey> : Entity<Tkey>
    {
        public int Version { get; protected set; }
        public List<IDomainEvent> Changes { get; private set; }

        public EventSourcedAggregate()
        {
            Changes = new List<IDomainEvent>();
        }

        public abstract void Apply(IDomainEvent domainEvent);
    }
}
