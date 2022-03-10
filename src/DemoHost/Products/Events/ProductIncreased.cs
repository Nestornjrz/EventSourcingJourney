using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHost.Products.Events
{
    public class ProductIncreased
    {
        public ProductIncreased(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
