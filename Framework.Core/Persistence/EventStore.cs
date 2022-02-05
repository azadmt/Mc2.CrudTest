using Framework.Core.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.Persistence
{
    //public class EventStore : IEventStore
    //{
    //    private readonly IEventBus _eventBus;

    //    private string EventStoreTableName = "EventStore";

    //    private static string EventStoreListOfColumns = "[Id], [AggregateId], [AggregateTypeName], [Data], [AggregateId], [Metadata], [Version],[IsSynced],[CreatedAt]";


    //    public EventStore(IEventBus eventBus)
    //    {
    //        _eventBus = eventBus;
    //    }
    //    public void CreateNewStream<TAggregate>(string streamName, IList<IDomainEvent> domianEvents)
    //    {            
    //        var eventStream = new EventStream($"{typeof(TAggregate).Name}_{streamName}");
    //        DocumentStore.Store(eventStream);

    //        AppendEvenetsToStream<TAggregate>(streamName, domianEvents);
    //    }

    //    public void AppendEvenetsToStream<TAggregate>(string streamName, IList<IDomainEvent> domianEvents)
    //    {
    //        var eventStream = DocumentStore.GetStream($"{typeof(TAggregate).Name}_{streamName}");
    //        foreach (var domianEvent in domianEvents)
    //        {
    //            var eventWrapper = eventStream.RegisEvent(domianEvent);
    //            DocumentStore.Store(eventWrapper);
    //            _eventBus.Publish(domianEvent);
    //        }
    
    //    }

    //    public IEnumerable<IDomainEvent> GetStream<TAggregate>(string streamName, int fromVersion, int toVersion)
    //    {
    //        var query = new StringBuilder($@"SELECT {EventStoreListOfColumns} FROM {EventStoreTableName}");
    //        query.Append(" WHERE [AggregateId] = @AggregateId ");
    //        query.Append(" ORDER BY [Version] ASC;");

    //        using (var connection = DbConnectionFactory.GetWrtieModelDbConnection())
    //        {
    //            var events = (await connection.QueryAsync<EventStoreDao>(query.ToString(), aggregateRootId != null ? new { AggregateId = aggregateRootId.ToString() } : null)).ToList();
    //            var domainEvents = events.Select(TransformEvent).Where(x => x != null).ToList().AsReadOnly();

    //            return domainEvents;
    //        }
    //        var eventWrappers = DocumentStore.GetWrappers($"{typeof(TAggregate).Name}_{streamName}", fromVersion, toVersion).OrderBy(p => p.EventNumber);
    //        var events = new List<IDomainEvent>();
    //        foreach (var eventWrapper in eventWrappers)
    //        {
    //            events.Add(eventWrapper.Event);
    //        }
    //        return events;
    //    }
    //}

    //public class EventStoreModel
    //{
    //    public Guid Id { get; set; }
    //    public string AggregateId { get; set; }
    //    public string AggregateType { get; set; }
    //    public string Data { get; set; }
    //    public string Metadata { get; set; }        
    //    public bool IsSynced { get; set; }
    //    public DateTime CreatedAt { get; set; }
    //}
}
