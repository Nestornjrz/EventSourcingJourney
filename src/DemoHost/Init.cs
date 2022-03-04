using Core;
using Core.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHost
{
    public static class Init
    {
        public static Container CreateContainer()
        {
            var container = new Container();
            var eventStore = new EventStore();
            var db = new EventSourcedRepository(eventStore);

            return container
                .Register(new ProductsCmdHandler(db))
                .Register(new ProductsQryHandler(db));
        }
    }
}
