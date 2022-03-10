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
            this.db.Products.Add(new ProductEntity(e.Id, 1));
        }
    }
}
