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
            var db = new RelationalDb();

            return container
                .Register(new ProductsCmdHandler(db))
                .Register(new ProductsQryHandler(db));
        }
    }
}
