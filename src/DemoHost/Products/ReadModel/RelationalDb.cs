namespace DemoHost.ReadModel
{
    public class RelationalDb
    {
        public RelationalDb()
        {
            this.Products = new List<ProductEntity>();
        }
        public List<ProductEntity> Products { get; set; }
    }

    public class ProductEntity
    {
        public ProductEntity(string id, string name, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Quantity = quantity;
        }
        public string Id { get; }
        public string Name { get; }
        public int Quantity { get; internal set; }
    }
}
