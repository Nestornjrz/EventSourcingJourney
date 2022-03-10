using Core;
using Core.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHost.TestHelper
{
    public class TestableEventSoucedRepository : IEventSourcedRepository
    {
        private readonly EventSourcedRepository repository;
        private readonly TestableEventStore store;

        public TestableEventSoucedRepository()
        {
            this.store = new TestableEventStore();
            this.repository = new EventSourcedRepository(this.store);
        }

        public T? Get<T>(string streamId) where T : EventSourced, new()
        {
            return this.repository.Get<T>(streamId);
        }

        public void Save<T>(T eventSourced) where T : EventSourced
        {
            this.repository.Save(eventSourced);
        }

        public void ThenOnly<T>(Action<T> asserts)
        {
            var e = this.store.Events.Single();
            asserts((T)e);
        }
    }
}
