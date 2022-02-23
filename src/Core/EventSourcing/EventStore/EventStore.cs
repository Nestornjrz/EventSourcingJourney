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
            if (!events.Any())
                throw new NotImplementedException();

            var streamLastVersion = txlog.Values
                .Where(x => x.StreamType == streamType && x.StreamId == streamId)
                .OrderByDescending(x => x.StreamVersion)
                .First().StreamVersion;

            if (streamLastVersion != expectedVersion)
                throw new Exception("Unexpected stream version");

            events.ForEach(e => this.txlog.Add(txlog.Keys.Count, e));
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
