using Core.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests
{
    public class GivenEventSourcedRepository
    {
        private EventSourcedRepository sut;

        public GivenEventSourcedRepository()
        {
            var eventStore = new EventStore();
            this.sut = new EventSourcedRepository(eventStore);
        }

        [Fact]
        public void when_saving_then_can_read()
        {
            var id = "1";
            var name = "Baturro";


            var employee = new Employee();
            employee.Update(new EmployeeCreated(id, name));
            this.sut.Save(employee);

            // Se lee en ES
            employee = this.sut.Get<Employee>(id);

            Assert.Equal(name, employee.Name);
            Assert.Equal(id, employee.Id);
            Assert.Equal(0, employee.Version);
        }
    }

    public class Employee : EventSourced
    {
        public string Name { get; private set; } = null!;

        protected override void Apply(object @event)
        {
            switch (@event)
            {
                case EmployeeCreated e:
                    this.Name = e.Name;
                    this.Id = e.Id;
                    break;
            }
        }
    }

    public class EmployeeCreated
    {
        public EmployeeCreated(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
