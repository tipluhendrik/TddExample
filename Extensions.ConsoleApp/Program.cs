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
            var fileString = File.ReadAllText("Database.json");
            var nodes = JsonSerializer.Deserialize<IEnumerable<Node>>(fileString);

            var nodeController = new NodeController();
            foreach(var node in nodes)
                {
                    System.Console.WriteLine("Node:");
                    nodeController.ToNodeView(node).Dump();
                }
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
