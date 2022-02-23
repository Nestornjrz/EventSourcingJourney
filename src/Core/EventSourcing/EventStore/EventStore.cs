using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class EventStore
    {
        private Dictionary<int, EventData> txlog = new Dictionary<int, EventData>();

        public List<EventData> ReadStream(string streamType, string streamId)
        {
            throw new NotImplementedException();
        }

        public void AppendStream(string streamType, string streamId, List<EventData> events, int expectedVersion)
        {
            if (!events.Any()) throw new NotImplementedException();

            var streamLastVersion = txlog.Values
                .ToList()
                .Where(x => x.StreamType == streamType)
                .OrderByDescending(x => x.StreamId)
                .First().StreamVersion;

            if (streamLastVersion != expectedVersion) throw new Exception("Unexpected stream version");

            events.ForEach(e =>
            {
                var key = txlog.Keys.Count + 1;
                this.txlog.Add(key, new EventData { StreamType = streamType, StreamId = streamId, Payload = e });
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventNumber">Cual fue el ultimo numero de evento procesado</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public object CreateSubscription(int? eventNumber)
        {
            throw new InvalidOperationException();
        }
    }
}
