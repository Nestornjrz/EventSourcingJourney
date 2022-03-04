using Core.EventSourcing;
using DemoHost.Products.Events;

namespace DemoHost.Products
{
    public class Product : EventSourced
    {
        public string Name { get; set; } = null!;
        public bool Removed { get; set; } = false;

        protected override void When(object @event)
        {
            switch (@event)
            {
                case ProductCreated e:
                    this.Name = e.Name;
                    this.Id = e.Id;
                    break;
                case ProductRemoved e:
                    this.Removed = true;
                    break;
            }
        }
    }
}
