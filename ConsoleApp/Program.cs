using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = ReadDatabase();

            var nodeController = new NodeController();
            var values = nodes.Select(nodeController.GetNode);

            foreach (var value in values)
            {
                value.Dump();
            }
        }

        private static IEnumerable<Node> ReadDatabase()
        {
            var fileString = File.ReadAllText("Data.json");

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            var nodes = JsonSerializer.Deserialize<IEnumerable<Node>>(fileString, options);

            return nodes;
        }
    }
        public static class DumpExtension
        {
            public static void Dump<T>(this T value)
            {
                var json = JsonSerializer.Serialize(value);
                Console.WriteLine(json);
            }
        }
}