using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Framework.Core.Persistence
{
    public static class DbConnectionFactory
    {
        static IConfiguration _configuration;
        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static IDbConnection GetReadModelDbConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("QueryDb"));
        }

        public static IDbConnection GetWrtieModelDbConnection()
        {
            return GetDbConnection(_configuration.GetConnectionString("WriteDb"));
        }

        private static IDbConnection GetDbConnection(string conection)
        {
            return new SqlConnection(conection);
        }
    }

    public class DocumentStore
    {
        private static List<EventWrapper> _eventWrappers = new List<EventWrapper>();
        private static List<EventStream> _eventStreams = new List<EventStream>();

        public static void Store(EventStream eventStream)
        {
            _eventStreams.Add(eventStream);
        }

        public static void Store(EventWrapper eventWrapper)
        {
            _eventWrappers.Add(eventWrapper);
        }

        public static IEnumerable<EventWrapper> GetWrappers(string eventStreamId, int fromVersion, int toVersion)
        {
            return _eventWrappers.Where(p => p.EventStreamId == eventStreamId && p.EventNumber >= fromVersion && p.EventNumber <= toVersion);
        }

        public static EventStream GetStream(string eventStreamId)
        {
            return _eventStreams.FirstOrDefault(p => p.Id == eventStreamId);
        }
    }
}
