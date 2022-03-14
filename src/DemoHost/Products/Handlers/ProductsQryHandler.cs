using Core.EventSourcing;
using DemoHost.ReadModel;

namespace DemoHost
{
    public class ProductsQryHandler
    {
        private readonly RelationalDb db;

        public ProductsQryHandler(RelationalDb db)
        {
            this.db = db;
        }

        public int GetQuantity(string id)
        {
            var product = this.db.Products.FirstOrDefault(x => x.Id == id);
            return product is null ? 0 : product.Quantity;
        }

        public List<ProductEntity> GetAllProducts()
        {
            return this.db.Products;
        }
    }
}
