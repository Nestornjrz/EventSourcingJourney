using Core;
using Core.EventSourcing;
using DemoHost.Products.Events;
using DemoHost.TestHelper;
using Xunit;

namespace DemoHost.Products.Tests
{
    public class given_no_product
    {
        private readonly ProductsCmdHandler cmdHandler;
        private readonly TestableEventSoucedRepository esRepository;

        public given_no_product()
        {
            this.esRepository = new TestableEventSoucedRepository();
            this.cmdHandler = new ProductsCmdHandler(esRepository);
        }

        [Fact]
        public void when_add_product_can_remove()
        {
            var id = "1";
            var name = "chocolate";
            this.cmdHandler.Add(id, name);


            this.esRepository.ThenOnly<ProductCreated>(e =>
            {
                Assert.Equal(id, e.Id);
                Assert.Equal(name, e.Name);
            });
        }
    }
}
