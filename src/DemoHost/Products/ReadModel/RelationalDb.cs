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
        public ProductEntity(string id, int quantity)
        {
            this.Id = id;
            this.Quantity = quantity;
        }
        public string Id { get; }
        public int Quantity { get; internal set; }
    }
}
