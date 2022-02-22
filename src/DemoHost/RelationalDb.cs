namespace DemoHost
{
    public class RelationalDb
    {
        public RelationalDb()
        {
            this.Products = new List<Product>();
        }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public Product(string id, int quantity)
        {
            this.Id = id;
            this.Quantity = quantity;
        }
        public string Id { get; }
        public int Quantity { get; internal set; }
    }
}
