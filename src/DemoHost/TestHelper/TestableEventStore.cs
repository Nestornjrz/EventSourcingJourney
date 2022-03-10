using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHost.TestHelper
{
    public class TestableEventStore : IEventStore
    {
        private readonly IEventStore eventStore;

        public TestableEventStore()
        {
            this.eventStore = new EventStore();
        }

        public List<object> Events { get; } = new List<object>();

        public void AppendStream(string streamType, string streamId, List<EventData> events, int expectedVersion)
        {
            this.Events.Clear();
            this.eventStore.AppendStream(streamType, streamId, events, expectedVersion);
            this.Events.AddRange(events.Select(x => x.Payload));
        }

        public EventStoreSubscription CreateSubscription(int? lastProcessedEventNumber, Action<int, EventData> handler)
        {
            return this.eventStore.CreateSubscription(lastProcessedEventNumber, handler);
        }

        public List<EventData> ReadStream(string streamType, string streamId)
        {
            return this.eventStore.ReadStream(streamType, streamId);
        }
    }
}
