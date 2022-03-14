using DemoHost.Products.Events;
using DemoHost.Products.ReadModel;
using DemoHost.ReadModel;
using Xunit;

namespace DemoHost.Products.Tests.ReadModel
{
    public class given_read_model_projection
    {
        protected readonly RelationalDb db = new RelationalDb();
        protected readonly ProductsReadModelProjection sut;

        public given_read_model_projection()
        {
            this.sut = new ProductsReadModelProjection(this.db);
        }
    }
    public class given_no_product : given_read_model_projection
    {
        [Fact]
        public void when_add_product_then_entity_is_projected()
        {
            var id = "1";
            var name = "chocolate";

            this.sut.Handle(new ProductCreated(id, name));

            var product = this.db.Products.First(x => x.Id == id);

            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(1, product.Quantity);
        }
    }

    public class given_a_product : given_read_model_projection
    {
        private readonly string id = "1";
        private readonly string name = "chocolate";

        public given_a_product()
        {
            this.sut.Handle(new ProductCreated(this.id, this.name));
        }

        [Fact]
        public void when_the_product_is_increased_then_its_increase_is_projected()
        {
            this.sut.Handle(new ProductIncreased(this.id, this.name));

            var product = this.db.Products.First(x => x.Id == id);

            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(2, product.Quantity);
        }

        [Fact]
        public void when_the_product_is_removed_the_product_is_removed_int_the_projection()
        {
            this.sut.Handle(new ProductRemoved(this.id));

            var product = this.db.Products.FirstOrDefault(x => x.Id == id);

            Assert.Null(product);
        }
    }
}
