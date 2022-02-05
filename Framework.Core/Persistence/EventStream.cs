using Framework.Core.Bus;

namespace Framework.Core.Persistence
{
    public class EventStream
    {
        public int Version { get; set; }
        public string Id { get; set; }// Aggregate Type + Id

        public EventStream(string id)
        {
            Id = id;
            Version = 0;
        }


        public EventWrapper RegisEvent(IDomainEvent @event)
        {
            Version++;
            return new EventWrapper(@event, Version, Id);
        }
    }
}
