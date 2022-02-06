using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Framework.Core.Persistence
{

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
