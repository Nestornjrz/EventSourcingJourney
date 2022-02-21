namespace DemoHost
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var cmd = Console.ReadLine()?.ToLower();


            while (cmd != "exit")
            {
                var tokens = cmd?.Split(" ");
                string? arg = null;

                if(tokens is not null && tokens.Length == 2)
                {
                    cmd = tokens[0];
                    arg = tokens[1];
                }

                switch (cmd)
                {
                    case Domain.Commands.Add:
                        Console.WriteLine($"Product Added {arg}");
                        break;
                    case Domain.Commands.Remove:
                        Console.WriteLine($"Product Removed {arg}");
                        break;
                    case Domain.Queries.GetQuantity:
                        Console.WriteLine($"Quantity Displayed {arg}");
                        break;
                    default:
                        Console.WriteLine("Invalid command try again");
                        break;
                }
                cmd = Console.ReadLine()?.ToLower();
            }
        }
    }
}