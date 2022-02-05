using Framework.Core.Bus;

namespace Framework.Core.Persistence
{
    public class EventWrapper
    {
        public string Id { get; private set; }
        public IDomainEvent Event { get; private set; }
        public string EventStreamId { get; private set; }
        public int EventNumber { get; private set; }

        public EventWrapper(IDomainEvent @event, int eventNumber, string eventStreamId)
        {
            Event = @event;
            EventNumber = eventNumber;
            EventStreamId = eventStreamId;
            Id = $"{eventStreamId}-{eventNumber}";
        }


    }
}
