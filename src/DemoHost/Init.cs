using Core;
using Core.EventSourcing;
using DemoHost.Products.ReadModel;
using DemoHost.ReadModel;

namespace DemoHost
{
    public static class Init
    {
        public static Container CreateContainer()
        {
            var container = new Container();
            var eventStore = new EventStore();
            var relationalDb = new RelationalDb();
            var readModel = new ProductsReadModelProjection(relationalDb);
            var es = new EventSourcedRepository(eventStore);

            eventStore.CreateSubscription(null, (eventNumber, e) =>
                ((dynamic)readModel).Handle((dynamic)e.Payload));

            return container
                .Register(new ProductsCmdHandler(es))
                .Register(new ProductsQryHandler(relationalDb));
        }
    }
}
