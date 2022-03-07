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
        private List<object> events = new List<object>();

        public TestableEventSoucedRepository()
        {
            var eventStore = new EventStore();
            this.repository = new EventSourcedRepository(eventStore);
        }

        public T Get<T>(string streamId) where T : EventSourced, new()
        {
            return this.repository.Get<T>(streamId);
        }

        public void Save<T>(T eventSourced) where T : EventSourced
        {

            this.repository.Save(eventSourced);
        }

        public void Entonces<T>(Action<T> asserts)
        {

        }
    }
}
