namespace DemoHost
{
    public class ProductsQryHandler
    {
        private readonly RelationalDb db;

        public ProductsQryHandler(RelationalDb db)
        {
            this.db = db;
        }

        public int GetQuantity(string id) =>
            this.db.Products.First(p => p.Id == id).Quantity;

        public List<Product> GetAllProducts() => this.db.Products;
    }
}
