using Core.EventSourcing;
using DemoHost.Products.Events;

namespace DemoHost.Products
{
    public class Product : EventSourced
    {
        public string Name { get; private set; } = null!;
        public bool Removed { get; private set; } = false;
        public int Amount { get; private set; }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case ProductCreated e:
                    this.Name = e.Name;
                    this.Id = e.Id;
                    this.Amount = 1;
                    break;
                case ProductRemoved e:
                    this.Removed = true;
                    break;
                case ProductIncreased:
                    this.Amount++;
                    break;
            }
        }
    }
}
