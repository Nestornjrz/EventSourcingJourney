using Core;
using Core.EventSourcing;
using Xunit;

namespace DemoHost.Products.Tests
{
    public class given_no_product
    {
        private readonly ProductsCmdHandler cmdHandler;
        private readonly EventSourcedRepository esRepository;
        private readonly EventStore eventStore;
        public given_no_product()
        {
            this.eventStore = new EventStore();
            this.esRepository = new EventSourcedRepository(eventStore);
            this.cmdHandler = new ProductsCmdHandler(esRepository);
        }

        [Fact]
        public void when_add_product_can_remove()
        {
            var id = "1";
            var name = "chocolate";
            this.cmdHandler.Add(id, name);

            

            
        }
    }
}
