using DemoHost.Products.Events;
using DemoHost.TestHelper;
using Xunit;

namespace DemoHost.Products.Tests
{

    public class given_command_handler
    {
        protected readonly ProductsCmdHandler cmdHandler;
        protected readonly TestableEventSoucedRepository esRepository;
        public given_command_handler()
        {
            this.esRepository = new TestableEventSoucedRepository();
            this.cmdHandler = new ProductsCmdHandler(esRepository);
        }
    }
    public class given_no_product : given_command_handler
    {

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

    public class given_a_product : given_command_handler
    {
        private readonly string id = "1";
        private readonly string name = "chocolate";

        public given_a_product()
        {
            this.cmdHandler.Add(this.id, this.name);
        }

        [Fact]
        public void when_the_product_is_added_then_it_is_added()
        {
            this.cmdHandler.Add(this.id, this.name);

            this.esRepository.ThenOnly<ProductIncreased>(e =>
            {
                Assert.Equal(id, e.Id);
                Assert.Equal(name, e.Name);
            });
        }

        [Fact]
        public void when_the_product_is_removed_then_it__is_removed()
        {
            this.cmdHandler.Remove(this.id);

            this.esRepository.ThenOnly<ProductRemoved>(e =>
            {
                Assert.Equal(id, e.Id);
            });

            var product = this.esRepository.Get<Product>(this.id);
            Assert.NotNull(product);
            Assert.True(product?.Removed);
        }
    }
}
