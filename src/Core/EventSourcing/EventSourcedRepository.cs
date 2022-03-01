using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.EventSourcing
{
    public class EventSourcedRepository
    {
        private readonly EventStore store;

        public EventSourcedRepository(EventStore store)
        {
            this.store = store;
        }

        public T Get<T>(string streamId)
        {
            throw new NotImplementedException();
        }

        public void Save<T>(T eventSourced) where T : EventSourced
        {

            this.store.AppendStream(eventSourced.StreamType, eventSourced.Id)
        }
    }
}
