using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHost.Products.Events
{
    public class ProductRemoved
    {
        public ProductRemoved(string id)
        {
            this.Id = id;
        }

        public string Id { get; }
    }
}
