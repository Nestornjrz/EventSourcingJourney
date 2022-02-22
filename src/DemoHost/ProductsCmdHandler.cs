namespace DemoHost
{
    public class ProductsCmdHandler
    {
        private readonly RelationalDb db;

        public ProductsCmdHandler(RelationalDb db)
        {
            this.db = db;
        }

        public void Add(string id)
        {
            var product = this.db.Products.FirstOrDefault(db => db.Id == id);
            if (product == null)
                this.db.Products.Add(new Product(id, 1));
            else
                product.Quantity += 1;
        }

        public void Remove(string id) =>
            this.db.Products.Remove(this.db.Products.First(x => x.Id == id));
    }
}
