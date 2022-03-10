using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EventSourcing
{
    public class EventSourcedRepository : IEventSourcedRepository
    {
        private readonly IEventStore store;

        public EventSourcedRepository(IEventStore store)
        {
            this.store = store;
        }

        public T? Get<T>(string streamId) where T : EventSourced, new()
        {
            var eventSourcedEntity = new T();
            var stream = this.store.ReadStream(eventSourcedEntity.StreamType, streamId);
            if (stream.Count == 0) return null;
            stream.ForEach(e => eventSourcedEntity.Apply(e.Payload));
            return eventSourcedEntity;
        }

        public void Save<T>(T eventSourced) where T : EventSourced
        {
            var uncommitedEvents = eventSourced.GetUncommitedEvents()
                .Select(x => new EventData()
                {
                    StreamId = eventSourced.Id,
                    StreamType = eventSourced.StreamType,
                    Payload = x
                })
                .ToList();

            var expectedVersion = eventSourced.Version - uncommitedEvents.Count();

            this.store.AppendStream(eventSourced.StreamType, eventSourced.Id,
                uncommitedEvents, expectedVersion);
        }
    }
}
