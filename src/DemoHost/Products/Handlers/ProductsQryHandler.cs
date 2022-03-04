using Core.EventSourcing;
using DemoHost.ReadModel;

namespace DemoHost
{
    public class ProductsQryHandler
    {

        public ProductsQryHandler(EventSourcedRepository repo)
        {
        }

        public int GetQuantity(string id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
