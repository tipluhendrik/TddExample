using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class NodeController
    {
        public IDictionary<string, string> GetNode(Node node)
        {
            var values = new Dictionary<string, string>();
            
            values["Name"] = node.Name;
            values["Priority"] = node.Priority.ToString();

            return values;
        }
    }
}