using Core.EventSourcing;
using DemoHost.Products.Events;
using DemoHost.Products;

namespace DemoHost
{
    public class ProductsCmdHandler
    {
        private readonly IEventSourcedRepository repo;

        public ProductsCmdHandler(IEventSourcedRepository repo)
        {
            this.repo = repo;
        }

        public void Add(string id, string name)
        {
            var product = new DemoHost.Products.Product();
            product.Update(new ProductCreated(id, name));
            repo.Save(product);
        }

        public void Remove(string id)
        {
            var product = this.repo.Get<DemoHost.Products.Product>(id);
            product.Update(new ProductRemoved(id));
            repo.Save(product);
        }
    }
}
