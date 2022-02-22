namespace DemoHost
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var container = Init.CreateContainer();
            var cmdHandler = container.Resolve<ProductsCmdHandler>();
            var qryHandler = container.Resolve<ProductsQryHandler>();

            Console.WriteLine("Type a command or a query, please: eg help");
            var req = Console.ReadLine()?.ToLower();

            while (req != "exit")
            {
                var tokens = req?.Split(" ");
                string? arg = null;

                if (tokens is not null && tokens.Length == 2)
                {
                    req = tokens[0];
                    arg = tokens[1];
                }

                switch (req)
                {
                    case Requests.Queries.Help:
                        Requests.DisplayAllRequests();
                        break;

                    case Requests.Commands.Add:
                        cmdHandler.Add(arg!);
                        Console.WriteLine($"Product Added {arg}");
                        break;

                    case Requests.Commands.Remove:
                        cmdHandler.Remove(arg!);
                        Console.WriteLine($"Product Removed {arg}");
                        break;

                    case Requests.Queries.GetQuantity:
                        var quantity = qryHandler.GetQuantity(arg!);
                        Console.WriteLine($"Quantity Displayed id:{arg}, quantity:{quantity}");
                        break;

                    case Requests.Queries.GetAllProducts:
                        var products = qryHandler.GetAllProducts();
                        Console.WriteLine($"Displaying {products.Count} product/s");
                        products.ForEach(x => Console.WriteLine($"id:{x.Id}, quantity:{x.Quantity}"));                        
                        break;

                    default:
                        Console.WriteLine("Invalid command try again");
                        break;
                }
                Console.WriteLine("Type a command or a query, please: eg help");
                req = Console.ReadLine()?.ToLower();
            }
        }
    }
}