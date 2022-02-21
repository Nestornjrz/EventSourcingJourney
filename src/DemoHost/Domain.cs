using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHost
{
    public static class Domain
    {
        public class Commands
        {
            public const string Add = "add";
            public const string Remove = "remove";
        }

        public class Queries
        {
            public const string GetQuantity = "getquantity";
        }
    }
}
