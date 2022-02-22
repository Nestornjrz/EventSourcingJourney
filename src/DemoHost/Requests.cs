namespace DemoHost
{
    public static class Requests
    {
        public class Commands
        {
            public const string Add = "add";
            public const string Remove = "remove";
        }

        public class Queries
        {
            public const string Help = "help";
            public const string GetQuantity = "getquantity";
            public const string GetAllProducts = "getallproducts";
        }

        public static void DisplayAllRequests()
        {
            Console.WriteLine(Commands.Add);
            Console.WriteLine(Commands.Remove);
            Console.WriteLine(Queries.Help);
            Console.WriteLine(Queries.GetQuantity);
            Console.WriteLine(Queries.GetAllProducts);
        }
    }
}
