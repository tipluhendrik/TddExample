using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = ReadDatabase();

            var nodeController = new NodeController();
            var values = nodes.Select(nodeController.GetValues);

            foreach (var value in values)
            {
                Dump(value);
            }
        }

        private static IEnumerable<Node> ReadDatabase()
        {
            var fileString = File.ReadAllText("Data.json");
            var nodes = JsonSerializer.Deserialize<IEnumerable<Node>>(fileString);
            return nodes;
        }
        
        private static void Dump(IDictionary<string, string> value)
        {
            System.Console.WriteLine("Node:");
            var serializerOptions = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(value, serializerOptions);
            Console.WriteLine(json);
        }
    }
}
