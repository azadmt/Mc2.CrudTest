using Dapper;
using Framework.Core.Bus;
using Framework.Core.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Framework.EventStore.Sql
{
    public class SqlServerEventStore : IEventStore
    {
        private readonly IEventBus _eventBus;

        private string EventStoreTableName = "EventStore";

        private static string EventStoreListOfColumns = "[Id], [AggregateId], [AggregateTypeName], [Data], [Metadata], [Version],[IsSynced],[CreatedAt]";

        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All,
            NullValueHandling = NullValueHandling.Ignore
        };

        public SqlServerEventStore(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public void CreateNewStream<TAggregate>(string aggregateRootId, IList<IDomainEvent> domianEvents)
        {
            if (domianEvents.Count == 0) return;
            AppendEvenetsToStream<TAggregate>(aggregateRootId, domianEvents.Count, domianEvents);
        }

        public void AppendEvenetsToStream<TAggregate>(string aggregateRootId, int aggregateRootVersion, IList<IDomainEvent> domianEvents)
        {
            if (aggregateRootVersion < domianEvents.Count)
                throw new ArgumentException("aggregateRootVersion is not valid!!!");

            var streamId = $"{typeof(TAggregate).Name}_{aggregateRootId}";
            int version = aggregateRootVersion - domianEvents.Count;
            var insertStreamSql =
                $@"INSERT INTO {EventStoreTableName} ({EventStoreListOfColumns})
                    VALUES (@Id, @AggregateId, @AggregateTypeName, @Data, @Metadata,@Version,@IsSynced,@CreatedAt);";

            var listOfEvents = domianEvents.Select(ev => new
          EventStoreModel
            {
                Id = Guid.NewGuid(),
                AggregateId = streamId,
                AggregateTypeName = typeof(TAggregate).FullName,
                Data = JsonConvert.SerializeObject(ev, Formatting.Indented, _jsonSerializerSettings),
                Metadata = string.Empty,
                Version = ++version,
                IsSynced = false,
                CreatedAt = ev.OccurDate,
                Event = ev
            }).ToList();

            using (var connection = DbConnectionFactory.GetWrtieModelDbConnection())
            {
                connection.Execute(insertStreamSql, listOfEvents);
                PublishProjectionEvent(listOfEvents, connection);
            }

        }

        public IEnumerable<IDomainEvent> GetStream<TAggregate>(string aggregateRootId, int fromVersion, int toVersion)
        {
            var query = new StringBuilder($@"SELECT {EventStoreListOfColumns} FROM {EventStoreTableName}");
            query.Append(" WHERE [AggregateId] = @AggregateId ");
            query.Append(" ORDER BY [Version] ASC;");

            using (var connection = DbConnectionFactory.GetWrtieModelDbConnection())
            {
                var events = (connection.Query<EventStoreModel>(query.ToString(), aggregateRootId != null ? new { AggregateId = aggregateRootId.ToString() } : null)).ToList();
                var domainEvents = events.Select(TransformEvent).Where(x => x != null).ToList().AsReadOnly();

                return domainEvents;
            }
            //var eventWrappers = DocumentStore.GetWrappers($"{typeof(TAggregate).Name}_{streamName}", fromVersion, toVersion).OrderBy(p => p.EventNumber);
            //var events = new List<IDomainEvent>();
            //foreach (var eventWrapper in eventWrappers)
            //{
            //    events.Add(eventWrapper.Event);
            //}
            //return domainEvents;
        }

        private void PublishProjectionEvent(IList<EventStoreModel> eventStoreModels, IDbConnection dbConnection)
        {
            var setSeyncedSql = $@"Update  {EventStoreTableName} Set IsSynced=1 WHERE Id=@Id";

            foreach (var eventStoreModel in eventStoreModels)
            {
                _eventBus.Publish(eventStoreModel.Event);
                dbConnection.Execute(setSeyncedSql, new { eventStoreModel.Id });
            }

        }
        private IDomainEvent TransformEvent(EventStoreModel eventSelected)
        {
            var o = JsonConvert.DeserializeObject(eventSelected.Data, _jsonSerializerSettings);
            var evt = o as IDomainEvent;

            return evt;
        }
    }

    public class EventStoreModel
    {
        public Guid Id { get; set; }
        public string AggregateId { get; set; }
        public string AggregateTypeName { get; set; }
        public string Data { get; set; }
        public IDomainEvent Event { get; set; }
        public string Metadata { get; set; }
        public bool IsSynced { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Version { get; set; }
    }
}
