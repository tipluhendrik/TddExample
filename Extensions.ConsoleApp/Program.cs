using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Extensions.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = ReadDatabase();

            var nodeController = new NodeController();

            var currencies = new[] { Currency.EUR, Currency.GBP, Currency.USD };
            foreach (var currency in currencies)
            {
                System.Console.WriteLine(currency.ToString());
                nodeController.GetBilanz(nodes, currency).Dump();
            }


            foreach (var node in nodes)
            {
                System.Console.WriteLine("Node:");
                nodeController.ToNodeView(node).Dump();
            }
        }

        private static IEnumerable<Node> ReadDatabase()
        {
            var fileString = File.ReadAllText("Database.json");
            var nodes = JsonSerializer.Deserialize<IEnumerable<Node>>(fileString);
            return nodes;
        }
    }
    public static class ObejctDumper
    {
        public static void Dump<T>(this T x)
        {
            var serializerOptions = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(x, serializerOptions);
            Console.WriteLine(json);
        }
    }
}
