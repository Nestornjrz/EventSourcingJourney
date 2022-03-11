using DemoHost.Products.Events;
using DemoHost.ReadModel;

namespace DemoHost.Products.ReadModel
{
    public class ProductsReadModelProjection
    {
        private readonly RelationalDb db;

        public ProductsReadModelProjection(RelationalDb db)
        {
            this.db = db;
        }

        public void Handle(ProductCreated e)
        {
            this.db.Products.Add(new ProductEntity(e.Id, e.Name , 1));
        }

        public void Handle(ProductIncreased e)
        {
            var product = this.db.Products.First(p => p.Id == e.Id);
            product.Quantity++;
        }

        public void Handle(ProductRemoved e)
        {
            var product = db.Products.First(p => p.Id == e.Id);
            db.Products.Remove(product);
        }
    }
}
